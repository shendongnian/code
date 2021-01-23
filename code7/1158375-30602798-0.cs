    foreach (string wrWG in workGroupLists)
    {
      HtmlGenericControl li = new HtmlGenericControl("li");
      li.InnerText = wrWG; 
      ulO.Controls.Add(li);
    }
