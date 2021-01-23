    using (var stringWriter = new StringWriter())
    {
           using (var page = new Page())
           {
                MyControl myControl = (MyControl)page.LoadControl("/Controls/myControl.ascx");
            
                var head = new HtmlHead();
                page.Controls.Add(head);
        
                var form = new HtmlForm();
                page.Controls.Add(form);
        
                var div = new HtmlGenericControl("div");
                div.ID = "myControlContent";
                form.Controls.Add(div);
        
                div.Controls.Add(myControl);
        
                HttpContext.Current.Server.Execute(page, stringWriter, false);
    
            }
            return stringWriter.ToString()
    }
