    tb.Columns.Add("ButtonColumn", typeof(Button));
   
    foreach(DataTable tb  in result.Tables)
    {
        foreach(DataRow r in tb.Rows)
        {
            r["ButtonColumn"] = new Button
                    {
                        Name = "rowButton",
                        Content = "Row Button Content",
                        Width = 100,
                        Height = 30
                    };
        }
    }
