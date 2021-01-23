    public string testMethodGEneric(object instance)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(JsonConvert.SerializeObject(instance));
        return sb.ToString();
    }
