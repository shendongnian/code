     Info record = null;
     var recordSet = new List<Info>();
     using (System.IO.StreamReader sr = new System.IO.StreamReader(sFile, Encoding.UTF8))
     {
        while ((line = sr.ReadLine()) != null)
        {
             if (record==null){
                    record = new Info();
                    recordSet.Add(record)
             }
             try {
             } catch ( Exception e) {
              //You either log the data or ignore the exception here
             }
             //Check your property here, replace with your actual implementation here
             if (record.ComputerID!=null && record.ApplicationName!=null) {
                   record = null;
             }
             
        }
     }
