    foreach (var item in navbarmenu)
    {
        // Move the following lines from outside the loop inside
        HtmlGenericControl dropdownLi = new HtmlGenericControl("li");
        dropdownLi.Attributes.Add("class", "dropdown");
        HtmlGenericControl mainMenuA = new HtmlGenericControl("a");    
        mainMenuA.InnerText = item.MenuName;
        dropdownLi.Controls.Add(mainMenuA);
        navUl.Controls.Add(dropdownLi);                    
    }  
