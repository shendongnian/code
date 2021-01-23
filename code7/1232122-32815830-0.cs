    using System;
    using System.Messaging;
    
    namespace MsmqTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                string invalidQueue = @"FormatName:DIRECT=OS:sometrahsname\private$\anothertrahsname";
                Enqueue("test", invalidQueue);
            }
    
            private static void Enqueue(object o, string queueName)
            {
                try
                {
                    MessageQueue msmq = null;
                    //check if queueName exists
                    //it also validates if you have access to MSMQ server
                    if (!MessageQueue.Exists(queueName))
                    {
                        msmq = MessageQueue.Create(queueName);
    
                        //you can also set the permission here
                        //because the other application that may be reading
                        //has different account with the application that created the queue
                        //set to Everyone for demonstration purposes
                        msmq.SetPermissions("Everyone", MessageQueueAccessRights.FullControl);
                    }
                    else
                    {
                        msmq = new MessageQueue(queueName);
                    }
    
                    using (msmq)
                    {
                        using (MessageQueueTransaction transaction = new MessageQueueTransaction())
                        {
                            msmq.DefaultPropertiesToSend.Recoverable = true;
                            transaction.Begin();
                            msmq.Send(new Message(o), transaction);
                            transaction.Commit();
                        }
                    }
                }catch(Exception)
                {
                    //handle error here
                }
            }
        }
    }
