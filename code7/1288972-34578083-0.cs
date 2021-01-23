    settings.Columns.Add(column =>
        {
            column.Settings.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            column.SetDataItemTemplateContent(c =>
            {				
                ViewContext.Writer.Write(string.Format("<button class=\"btn btn-primary btn-xs additem\" title=\"Add\" data-id=\"{0}\"><i class=\"fa fa-edit\"></i></button>", DataBinder.Eval(c.DataItem, "Id")));
                ViewContext.Writer.Write(string.Format("<button class=\"btn btn-danger btn-xs deleteitem\" title=\"Delete\" data-id=\"{0}\"><i class=\"fa fa-trash\"></i></button>", DataBinder.Eval(c.DataItem, "Id")));
				ViewContext.Writer.Write(string.Format("<button class=\"btn btn-primary btn-xs updateitem\" title=\"Update\" data-id=\"{0}\"><i class=\"fa fa-edit\"></i></button>", DataBinder.Eval(c.DataItem, "Id")));
            });
        });
