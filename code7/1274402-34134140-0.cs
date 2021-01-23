    private JObject body;
    public string Body
    {
        get { return body.ToString(); }
        set { body = JObject.Parse(value); }
    }
    public void SetBody(JObject body)
    {
        this.body = body;
    }
    public void SetBody(IDictionary<string, object> body)
    {
        ...
    }
