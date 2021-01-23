    public void InitiateTable() 
    {
        var literalControlValue = new StringBuilder();
        literalControlValue.Append("<table class=\"table table-invoice\" >"); 
        ...
        literalControlValue.Append("</thead>"));
        mytable.Text = literalControlValue.ToString();
    }
