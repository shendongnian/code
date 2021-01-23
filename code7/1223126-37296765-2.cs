    // using a Model
    string html = view.Render("Emails/Test", new Product("Apple"));
    // using a Dictionary<string, object>
    var viewData = new Dictionary<string, object>();
    viewData["Name"] = "123456";
    string html = view.Render("Emails/Test", viewData);
