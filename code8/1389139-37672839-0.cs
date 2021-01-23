        foreach (var item in ModelList)    // ModelList must be your List of model variable
        {
         sqls = "select sum(Disc)as D from table
                 where P = Html.DisplayFor(modelItem => item.Price)";
         DB.Open();
         DataSet ds = new DataSet();
         ds = DB.getData(sqls);
         int P =ds.Tables[0].Rows[0]["D"];
         item.P = P;                     //assigning to a new property P
        }
       
       return View(ModelList);
