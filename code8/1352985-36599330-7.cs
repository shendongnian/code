    namespace My.Application.Web.Controllers
    {
        using Security;
        using My.Application.Diagnostics;
        using My.Application.Framework.Configuration;
        using My.Application.Models;
        using My.Application.Process;
        using System;
        using System.Configuration;
        using System.Diagnostics;
        using System.IO;
        using System.Linq;
        using System.Messaging;
        using System.Net;
        using System.Net.Http;
        using System.Web.Http;
        using System.Web.Http.Cors;
        using System.Xml.Linq;
        using System.Xml.Serialization;
    
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public class OutboundEventController : ApiControllerBase
        {
            #region <Actions>
    
            [HttpGet]
            public HttpResponseMessage Ping()
            {
                TraceHandler.TraceIn(TraceLevel.Info);
                
                if (Request.Headers.Referrer == null)
                    TraceHandler.TraceAppend(MESSAGE_REFERRER_NULL);
    
                if (Request.Headers.Referrer != null)
                    TraceHandler.TraceAppend(string.Format(FORMAT_REFERRER, Request.Headers.Referrer));
    
                TraceHandler.TraceOut();
                return Request.CreateResponse(HttpStatusCode.OK, "Ping back at cha...");
            }
    
            [HttpPost]
            [EnableWebApiCorsFromAppSettings("EnableCors.Origins")]
            public HttpResponseMessage Enqueue(HttpRequestMessage request)
            {
                TraceHandler.TraceIn(TraceLevel.Info);
    
                if (Request.Headers.Referrer == null)
                    TraceHandler.TraceAppend(MESSAGE_REFERRER_NULL);
    
                if (Request.Headers.Referrer != null)
                    TraceHandler.TraceAppend(string.Format(FORMAT_REFERRER, Request.Headers.Referrer));
    
                try 
                {
                    // Do Amazing Stuff Here...
    
                    TraceHandler.TraceAppend(FORMAT_ENQUEUED_SUCCESS, claimId);
                }
                catch (Exception ex)
                {
                    TraceHandler.TraceError(ex);
                    TraceHandler.TraceOut();
    
                    EnqueueToPoison(ex, claimMessage);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, GetHttpError());
                }
    
                TraceHandler.TraceOut();
    
                // FORCE: Correct Header
                var response = Request.CreateResponse(HttpStatusCode.OK, string.Format(FORMAT_ENQUEUED_SUCCESS, claimId));
                response.Headers.Add("Access-Control-Allow-Origin", "*");
                return response;
            }
    
            #endregion
    
            private string GetClaimId(HttpRequestMessage request)
            {
                var stream = request.Content.ReadAsStreamAsync().Result;
                var xdoc = XDocument.Load(stream);
                var result = GetElementValue(xdoc, "ClaimId");
    
                return result;
            }
    
            private ClaimMessage CreateClaimMessage(string claimId, string process)
            {
                ClaimMessage message = new ClaimMessage();
    
                message.ClaimID = claimId;
                message.Process = process;
    
                return message;
            }
    
            private void Enqueue(ClaimMessage claimMessage)
            {
                var queueName = ConfigurationManager.AppSettings[Settings.Messaging.Queue.Name].ToString();
                var queue = new MessageQueue(queueName);
                queue.DefaultPropertiesToSend.Recoverable = true;
    
                TraceHandler.TraceAppend(FORMAT_QUEUE_NAME, queueName);
    
                MessageQueueTransaction transaction;
                transaction = new MessageQueueTransaction();
                transaction.Begin();
    
                var message = new System.Messaging.Message();
                message.Formatter = new XmlMessageFormatter(new Type[] { typeof(ClaimMessage) });
    
                message.Label = "ClaimID " + claimMessage.ClaimID;
    
                message.Body = claimMessage;
                queue.Send(message, transaction);
    
                transaction.Commit();
                queue.Close();
            }
    
            private void EnqueueToPoison(Exception exception, ClaimMessage claimdata)
            {
                TraceHandler.TraceIn(TraceLevel.Info);
    
                var poison = ToPoisonMessage(exception, claimdata);
                var message = new System.Messaging.Message();
    
                try
                {
                    var poisonQueueName = ConfigurationManager.AppSettings[Settings.Messaging.PoisonQueue.Name].ToString();
    
                    TraceHandler.TraceAppend(FORMAT_QUEUE_NAME, poisonQueueName);
    
                    if (MessageQueue.Exists(poisonQueueName))
                    {
                        var queue = new MessageQueue(poisonQueueName);
                        queue.DefaultPropertiesToSend.Recoverable = true;
    
                        var transaction = new MessageQueueTransaction();
                        transaction.Begin();
    
                        message.Formatter = new XmlMessageFormatter(new Type[] { typeof(PoisonClaimMessage) });
                        message.Label = "Poison ClaimID " + poison.ClaimID;
    
                        var xmlSerializer = new XmlSerializer(poison.GetType());
                        xmlSerializer.Serialize(message.BodyStream, poison);
    
                        queue.Send(message, transaction);
    
                        TraceHandler.TraceAppend(FORMAT_ENQUEUED_POISON_SUCCESS, poison.ClaimID);
    
                        transaction.Commit();
                        queue.Close();
                    }
                }
                catch(Exception ex)
                {
                    // An error occurred while enqueuing to POISON
                    var poisonXml = ToString(poison);
    
                    TraceHandler.TraceError(ex);
                    TraceHandler.TraceAppend(poisonXml);
                }
                finally
                {
                    TraceHandler.TraceOut();
                }
            }
    
    
            #endregion
        }
    }
    
