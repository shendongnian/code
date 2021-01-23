    using (StreamWriter writer = new StreamWriter("testdata.txt", true))
                {
    
                    for (int i = 1; i <= 1500; i++)
                    {
                        writer.Write(i +",");
                    }
                }
