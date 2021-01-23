    [HttpPost]
    publict ActionResult DynamicRows(FormCollection f)
    {
        int i = Convert.ToInt32(f["level"]); // you will set the number of rows added from JQuery
        for (int a = 0; a <= i; a++)
        {
             ABC lvl = new ABC();
             lvl.S1 = a.ToString();
             lvl.N1 = a;
             lvl.N2 = Convert.ToInt32(f["codelen" + a.ToString()]); // here you are getting back the values as codelen1..codelen2..codelen3
             
             // your other logic comes here... anything you want to do with the data
             WebDb.ABC.Add(lvl);
             
        }
        WebDb.SaveChanges();
    }
