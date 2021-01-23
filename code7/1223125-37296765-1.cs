    // using a Model
    string viewHtml = view.Render("Emails/Test", new Product("Apple"));
    // using a Dictionary<string, object>
    var viewData = new Dictionary<string, object>();
    viewData["Name"] = "123456";
    string viewHtml = view.Render("Emails/Test", viewData);
