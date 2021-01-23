    HtmlGenericControl rootUl, parentLi, childLi;
    // create the html list
    rootUl = new HtmlGenericControl("ul");
    // our name-control mapping
    var controls = new Dictionary<string, HtmlGenericControl>();              
    // our data
    var items = new[]{
        "fish>shark>mako",
        "fish>shark>tiger",
        "fish>clown fish>nemo",
        "birds>eagle>bald eagle",
        "birds>hawk",
    };        
    // loop through the data items
    foreach (var item in items)
    {
        // split by the greater-than symbol
        var names = item.Split('>');
        // if we don't already have a control for the topmost parent...
        if (!controls.TryGetValue(names[0], out parentLi))
        {
            // create the control and store it in our mapping
            controls[names[0]] = parentLi = new HtmlGenericControl("li")
            {
                InnerText = names[0]
            };               
            // add it to the html list
            rootUl.Controls.Add(parentLi);
        }
        // loop through the remaining parts
        foreach (var name in names.Skip(1))
        {
            // if the parent doesn't have a list-child...
            if (parentLi.Controls.Count == 1)
            {
                // add an html list child to the parent
                parentLi.Controls.Add(new HtmlGenericControl("ul"));
            }
            // if we don't already have a control for the child...
            if (!controls.TryGetValue(name, out childLi))
            {
                // create the control
                controls[name] = childLi = new HtmlGenericControl("li"){
                    InnerText = name
                };
            }
            // add the child to the parent's html list
            parentLi.Controls[1].Controls.Add(childLi);
            // keep a reference to the child for further nesting
            parentLi = childLi;
        }
    }
    // add the html list to the form
    form1.Controls.Add(rootUl);
