                var message = Encoding.Default.GetString(dataPoint.Message);
                int messageSize=0;
                byte nullByte = 0x00;
                for (int k=0; k < dataPoint.Message.Count(); k++)
                {
                    if (dataPoint.Message.ElementAt(k).Equals(nullByte))
                    {
                        messageSize = k+1;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                message = message.Substring(0, messageSize);
