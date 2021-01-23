    List<ListItem> files = new List<ListItem>();
    files.Add(new ListItem("~/Images/SomeImage.jpg"));
        
    GridView2.DataSource = files;
    GridView2.DataBind();
