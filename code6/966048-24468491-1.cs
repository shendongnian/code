            public void Test()
        {
            //C#
            System.IO.StreamWriter writer = null;
            try
            {
                writer = new System.IO.StreamWriter("me01111.txt", true);
                writer.WriteLine("Hey"); //saved 
            }
            finally
            {
                if (writer != null) //Flush data
                {
                    ((IDisposable)writer).Dispose();
                }
            }
        }
