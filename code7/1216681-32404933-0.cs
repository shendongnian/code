    var app = new ApplicationUnderTest();
    var x = new UITestControl(app);
    x.SearchProperties.Add("Key","Value");
    x.SearchProperties.Add("Key","Value");
    x.SearchProperties.Add("Key","Value");
    
    Mouse.Click(x,x.GetClickablePoint());
