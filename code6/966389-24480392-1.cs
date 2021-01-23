    Parallel.ForEach(xRoot.Elements("key"), xKey =>
    {
       try
       {
          int id = int.Parse(xKey.Attribute("id").Value); // maybe null reference here?
          string code = xKey.Attribute("code").Value; // or here?
          AccountStatus accountStatus = SomeClient.GetAccountStatusAsync(id, code).Result; // or even here?
       }
       catch (Exception ex)
       {
          throw; // add here a breakpoint and check what's up by checking 'ex' object
       }
    );
