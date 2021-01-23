    //If the parse is simple it can be done inline with the dictionary creation
    private string GenerateKey(string fullString)
    {
       //parse key from original string and return
    }
    //If the parse is simple it can be done inline with the dictionary creation
    private string GenerateValue(string fullString)
    {
         //Parse Values from your original string and return
    }
    private void UsageMethod(IEnumerable<fullString> sprachs)
    {
          var dictionary = sprachs.ToDictionary(
                                  fString => GenerateKey(fString), //The Key
                                  fString => GenerateValue(fString) //The Value
                           );
          //Now you can use Dicitonary as it is a IDictionary<string,string>
          // so it too can be overriden an extended if need be
    }
