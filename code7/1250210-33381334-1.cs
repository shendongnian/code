    for(int i = 0; i < requestBytes.Length; i++)
                    {
                        var v = requestBytes[i];
                        if (v == 99)
                        {
                            Console.WriteLine("Sending Failure..");
                        }
                        else if(v == 999)
                        {
                            Console.WriteLine("Message Failure..");
                        }
                        else if (v == 01)
                        {
                            Console.WriteLine("Sending Success..");
                        }
    
                    }
