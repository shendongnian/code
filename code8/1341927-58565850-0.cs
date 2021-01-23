    using Example.Models;
    using Example.Repositories;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace Example.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class SseMessagesController : ControllerBase
        {
            private readonly IMessageRepository messageRepository;
            private readonly JsonSerializerSettings jsonSettings;
    
            public SseMessagesController(IMessageRepository messageRepository)
            {
                this.messageRepository = messageRepository;
                this.jsonSettings = new JsonSerializerSettings();
                jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }
    
            [HttpGet]
            public async Task GetMessages(CancellationToken cancellationToken)
            {
                Response.StatusCode = 200;
                Response.Headers.Add("Content-Type", "text/event-stream");
    
                EventHandler<MessageCreatedArgs> onMessageCreated = async (sender, eventArgs) =>
                {
                    try
                    {
                        var message = eventArgs.Message;
                        var messageJson = JsonConvert.SerializeObject(message, jsonSettings);
                        await Response.WriteAsync($"data:{messageJson}\n\n");
                        await Response.Body.FlushAsync();
                    }
                    catch (Exception)
                    {
                        // TODO: log error
                    }
                };
                messageRepository.MessageCreated += onMessageCreated;
    
                while (!cancellationToken.IsCancellationRequested) {
                    await Task.Delay(1000);
                }
    
                messageRepository.MessageCreated -= onMessageCreated;
            }
        }
    }
