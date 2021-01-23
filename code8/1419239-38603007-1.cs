    string message = String.Empty;
    bool ContainsBracketsWithString = AssertionValue.All(a =>
                 CredentialTypeDescription.Any(b => {
                         var passed = a.Field1 == b.Field1;
                         if(!passed && String.IsNullOrEmpty(message)){
                            message = "Some message to identify which failed"; 
                         }
                         return passed;
                     })
                   );
    
    Assert.False(ContainsBracketsWithString, message);
