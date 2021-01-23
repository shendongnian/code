    var fails = new List<string>();
    bool ContainsBracketsWithString = AssertionValue.All(a =>
                 CredentialTypeDescription.Any(b => {
                         var passed = a.Field1 == b.Field1;
                         if(!passed){
                            fails.Add("Some message to identify which failed"); 
                         }
                         return passed;
                     })
                   );
    
    Assert.False(ContainsBracketsWithString, String.Join(Environment.NewLine, fails));
