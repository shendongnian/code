    [HttpPost]
    public string PostData(System.Net.Http.Formatting.FormDataCollection form)
    {
        string name=form.get("name");
        string phone=form.get("phone");
        string sex=form.get("sex");
    }
