    protected override void OnPreInit(EventArgs e)
    {
        if(!this.IsPostBack)
        {
           this.ColumnsList.Items.Add(new ListItem { Text= "Text1"  Value = "value1"    });
           this.ColumnsList.Items.Add(new ListItem { Text= "Text2"  Value = "value2"  });
        }
    }
