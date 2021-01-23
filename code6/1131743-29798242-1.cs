    public void Post(object sender, EventArgs e)
    {
        string[] textboxValues = Request.Form.GetValues("DynamicTextBox");
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        this.Values = serializer.Serialize(textboxValues);
        string message = "";
        foreach (string textboxValue in textboxValues)
        {
            message += textboxValue + "\\n";
        }
    }
