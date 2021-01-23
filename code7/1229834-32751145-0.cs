    HtmlGenericControl list = new HtmlGenericControl("ul");
    HtmlGenericControl li = new HtmlGenericControl("li");
    
    HyperLink a = new HyperLink();
    a.NavigateUrl = "index.html";
    a.Attributes.Add("style", "font-size: 18px; color: black");
    
    HtmlGenericControl i = new HtmlGenericControl("i");
    i.Attributes.Add("class", "glyphicon glyphicon-info-sign");
    i.Attributes.Add("style", "color:black");
    i.InnerText = "Truck Data";
    
    a.Controls.Add(i);
    				
    li.Controls.Add(a);
    list.Controls.Add(li);
    
    sidemenu.Controls.Add(list);
