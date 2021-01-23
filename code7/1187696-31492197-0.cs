     foreach (byte[] outData in _taskQ.GetConsumingEnumerable())
     {
         using(StreamWriter fwriter=new StreamWriter("C:\\testsave\\dataProc",true))
                    {
                        for (int i = 0; i < datalen; i++)
                        {
                            fwriter.Write(outData[i]);
                            fwriter.Write(",");
                        }
                        fwriter.Write("\n");
                    }
     }
