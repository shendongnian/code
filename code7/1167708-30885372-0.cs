    for (int x = 0; x < 30; x++)
    {
         TextBox txt = new TextBox();
         txt.ID = "txt - " + x.ToString(); 
         txt.CssClass = "form-control"; //Assign a css class to your textbox
         data.Controls.Add(txt);
         data.Controls.Add(new LiteralControl("<br/>"));
    }
