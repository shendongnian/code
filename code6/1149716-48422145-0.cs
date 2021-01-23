                using (NetworkStream stream = Client.GetStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    //just use the bellow code like(from sr.EndOfStream to reader.Peek()>=0)
                    while (reader.Peek() >= 0)
                    {
                        String message = reader.ReadLine();
                        ProcessMessage(message);
                    }
                }
            }
