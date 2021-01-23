    writer02.Close();
--------------:
 
    public void Test()
        {
            //C#
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter("me00.txt", true))
            {
                writer.WriteLine("Hey"); 
            }
        }
