    var fn = "Test.mot";
    using (StreamReader sr = new StreamReader(fn))
    {    
         var record = recordList.Single(r=> r.FileName);
         String line =String.Empty;
         while ((line = sr.ReadLine()) != null)
         {        
    
             if (line.SubString(4,6) == record.Id && line.SubString(10, record.Data.Length) == record.Data)
             {
                 Console.WriteLine("Success");
             }
             else
             {
                 Console.WriteLine("Failure");
             }
         }
    }
