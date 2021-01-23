    public ActionResult fileread()
    {
         var excel = new ExcelQueryFactory(@"File Name");
         excel.AddMapping<ABC>(x => x.S1, "code");        // ABC is your database table name... code is the column name of excel file
         excel.AddMapping<ABC>(x => x.S2, "description");    
         // you can map as many columns you want    
         var e = (from c in excel.Worksheet<ABC>("MyExcelFile") select c); // MyExcelFile is the name of Excel File's Sheet name
     
    // similarly you can do whatever you want with the data like.. save to DB
       foreach (var y in e)
       {
           ABC a = new ABC();
           a.S1 = y.S1;
           a.S2 = y.S2;
           db.ABC.Add(a);
       }
       db.SaveChanges();
    }
 
