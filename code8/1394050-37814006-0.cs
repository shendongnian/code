    Request.Form.Keys.OfType<string>().ToList().FindAll(k => k.StartsWith("page")).ForEach(inputName =>
    {
        var value = Request.Form[inputName];
        var index = Int32.Parse(inputName.Substring(4));
        //handle value...
    });
