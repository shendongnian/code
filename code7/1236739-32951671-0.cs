    using(context db = new context())
    {
        List<Table2> var1 = db.Table2.ToList()
        List<Table2> var2 = new List<Table2>()
        foreach(Table2 t in var1)
        {
            if(t.FieldValue == textbox.Text)
            {
                var2.Add(t);
            }
        }
    }
