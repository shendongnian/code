    using System;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using IBM.WMQ;
    using IBM.WMQ.PCF;
    
    namespace PCFNET
    {
        class Program
        {
            static void Main(string[] args)
            {
                InquireQueue();
            }
        /// <summary>
        /// Display list of queue names and queue depth for each queue
        /// </summary>
        public static void InquireQueue()
        {
            PCFMessageAgent messageAgent = null;
            try
            {
                // Create bindings connection to queue manager
                messageAgent = new PCFMessageAgent("DEMOQMGR");
                // Build Inquire command to query queue name
                PCFMessage reqeuestMessage = new PCFMessage(MQC.MQCMD_INQUIRE_Q);
                reqeuestMessage.AddParameter(MQC.MQCA_Q_NAME, "*");
                // Send request and receive response
                PCFMessage[] pcfResponse = messageAgent.Send(reqeuestMessage);
                // Process and print response.
                int pcfResponseLen = pcfResponse.Length;
                for (int pcfResponseIdx = 0; pcfResponseIdx < pcfResponseLen; pcfResponseIdx++)
                {
                    try
                    {
                        String qName = pcfResponse[pcfResponseIdx].GetStringParameterValue(MQC.MQCA_Q_NAME);
                        int qDepth = pcfResponse[pcfResponseIdx].GetIntParameterValue(MQC.MQIA_CURRENT_Q_DEPTH);
                        Console.WriteLine("QName: " + qName + "  Depth: " + qDepth);
                    }
                    catch (PCFException pcfex)
                    {
                        //Ignore exception and get the next response
                    }
                }
            }
            catch (PCFException pcfEx)
            {
                Console.Write(pcfEx);
            }
            catch (MQException ex)
            {
                Console.Write(ex);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            finally
            {
                if (messageAgent != null)
                    messageAgent.Disconnect();
            }
        }
    }
}
