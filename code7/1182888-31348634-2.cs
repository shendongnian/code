    public string RevertEntities(string test)
    {
       Regex rxHttpEntity = new Regex(@"(&[#\w]+;)");
       string last_res = string.Empty;
       while (rxHttpEntity.IsMatch(test))
       {
           test = test.Replace(rxHttpEntity.Match(test).Value, HttpUtility.HtmlDecode(rxHttpEntity.Match(test).Value.ToLower()));
           if (last_res == test)
               break;
           else
               last_res = test;
        }
        return test;
    }
