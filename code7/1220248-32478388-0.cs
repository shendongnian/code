    HtmlGenericControl liControl;
    
    if (startPage > 1) {
    	liControl = new HtmlGenericControl("li");
    	liControl.InnerHtml = "First...";
    	pagenav.Controls.Add(liControl);
    }
    
    for (int i = startPage; i <= endPage; i++) { 
    	liControl = new HtmlGenericControl("li");
    	liControl.InnerHtml = i.ToString();
    	pagenav.Controls.Add(liControl);
    }
    
    if (endPage < totalPage) {
    	liControl = new HtmlGenericControl("li");
    	liControl.InnerHtml = "...Last";
    	pagenav.Controls.Add(liControl);
    }
