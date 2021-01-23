    public string RevertEntities(string test)
    {
       Regex rxHttpEntity = new Regex(@"(&[#\w]+;)"); // Declare a regex (better initialize it as a property/field of a static class for better performance
       string last_res = string.Empty; // a temporary variable holding a previously found entity
       while (rxHttpEntity.IsMatch(test)) // if our input has something like &#101; or &nbsp;
       {
           test = test.Replace(rxHttpEntity.Match(test).Value, HttpUtility.HtmlDecode(rxHttpEntity.Match(test).Value.ToLower())); // Replace all the entity references with there literal value (&amp; => &)
           if (last_res == test) // Check if we made any change to the string
               break; // If not, stop processing (there are some unsupported entities like &ourgreatcompany;
           else
               last_res = test; // Else, go on checking for entities
        }
        return test;
    }
