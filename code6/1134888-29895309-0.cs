    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "employees")]
    public List<Dictionary<string, string>> GetEmployees()
    {
        var c = Employee.GetList().Select(x => new Dictionary<string, string> {{"id", x.Id.ToString()}, {"title",x.Title}, {"person", "x.FullName"}}).ToList();
        return c;
    }
