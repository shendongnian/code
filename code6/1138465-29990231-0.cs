    foreach(DataTable table in Tables)
    {
        MyChildControl childControl = new MyChildControl();
        childControl.Confiure(table); // Sets the data for the control.
        layoutPanel.Controls.Add(childControl); // This call varies by UI method and what layoutPanel you are using
    }
