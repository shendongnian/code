    using Microsoft.ApplicationInsights;
    using Microsoft.ApplicationInsights.DataContracts;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.ServiceBus;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using System;
    using AzureMonitorFunctions.WebHook;
    
    
    
    namespace MyFunctions
    {
        public static class MyEventhubTrigger
        {               
    
            [FunctionName("MyEventhubTrigger")]       
           public static async void Run([EventHubTrigger("%EventHubName%", Connection = "EventHubConnectionString", ConsumerGroup = "devicestatuscg")] string myEventHubMessage, DateTime enqueuedTimeUtc, Int64 sequenceNumber, string offset, ILogger log)
            {           
                log.LogInformation($"C# Event Hub trigger function processed a message: {myEventHubMessage}");
                try
                {                 
                    StorageTableOperation<StorageTable> tableObj = new StorageTableOperation<StorageTable>("EventhubMessages");
                    Eventhubstorage Eventhubdada = tableObj.GetTableData("Eventhub", "DeviceStatus");
                    if (Eventhubdada.EnqueuedTime < enqueuedTimeUtc)
                    {                    
                            Eventhubdada.EnqueuedTime = enqueuedTimeUtc;
                            Eventhubdada.Offset = offset;
                            Eventhubdada.Sequence = sequenceNumber;
                            await tableObj.UpdateTableData("Eventhub", "DeviceStatus", Eventhubdada);
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    log.LogInformation(ex.ToString());
                }
            }
        }
    }
