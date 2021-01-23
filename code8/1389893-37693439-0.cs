    for (c = 0; c <= num; c++)
    {
      TextBox txtRun = new TextBox();
      HtmlGenericControl div = new HtmlGenericControl("div");
      div.Controls.Add(txtRun);
      div.Attributes.Add("class", "txtContainer");
      divContainer.Controls.Add(div);
    }     
