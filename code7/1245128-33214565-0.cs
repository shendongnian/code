       string line = null;
       using (StreamReader reader = new StreamReader(@"U2.txt"))
       {
           string eilute = null;
           while (null != (eilute = reader.ReadLine()))
           {
               string[] values = eilute.Split(' ');
               var noOfElement = values.Length;
           }
       }
