        if (!IsPostBack)
        {
            System.Drawing.Color c1 = new System.Drawing.Color();
            Type t = c1.GetType();
            int row;
            foreach (System.Reflection.PropertyInfo p1 in t.GetProperties())
            {
                ColorConverter d = new ColorConverter();
                try
                {
                    DropDownList2.Items.Add(p1.Name);
                    for (row = 0; row < DropDownList2.Items.Count - 1; row++)
                    {
                        DropDownList2.Items[row].Attributes.Add("style",
                              "background-color:" + DropDownList2.Items[row].Value);
                      }
                    }
                catch
                {
                    // Catch exceptions here
                }
            }
    }
}
