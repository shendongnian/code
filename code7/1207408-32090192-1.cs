                PCFMessage reqeuestMessage = new PCFMessage(MQC.MQCMD_INQUIRE_Q);
                reqeuestMessage.AddParameter(MQC.MQCA_Q_NAME, "Q1");
                // Send request and receive response
                PCFMessage[] pcfResponse = messageAgent.Send(reqeuestMessage);
                // Process and print response.
                int pcfResponseLen = pcfResponse.Length;
                for (int pcfResponseIdx = 0; pcfResponseIdx < pcfResponseLen; pcfResponseIdx++)
                {
                    PCFParameter[] parameters = pcfResponse[pcfResponseIdx].GetParameters();
                    foreach (PCFParameter pm in parameters)
                    {
                        // We just want to print current queue depth only
                        if ((pm.Parameter == MQC.MQIA_OPEN_OUTPUT_COUNT) || (pm.Parameter == MQC.MQIA_OPEN_INPUT_COUNT))
                            Console.WriteLine("Parameter: " + pm.Parameter + " - Value: " + pm.GetValue());
                    }
                }
