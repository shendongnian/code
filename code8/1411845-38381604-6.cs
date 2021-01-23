                catch (Exception ex)
                {
                    Console.WriteLine("Unable to Serialize from binary format");
                    Console.WriteLine(ex.Message);
                }
            }
            private static Object Deserialize(FileStream fs)
            {
                
                try
                {
                   stream1.Position = 0;
