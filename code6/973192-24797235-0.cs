     settings.Columns.Add(column =>
                {
                    column.Caption = "archiveren";
                    column.SetDataItemTemplateContent(c =>
                    {
                        ViewContext.Writer.Write("<input type=\"button\" value=\"archive\" />");
                    });
    
    
                });
