    List<string> name = new List<string>() {
                         {"James"}, {"Harry"}
                };
        Literal1.Text = "<ul>";
        foreach (var n in name)
        {
            Literal1.Text += "<li>"+n+"</li>";
           
        }
        Literal1.Text += "<ul/>";
