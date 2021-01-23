    // This throws an IsolatedStorageException, since we haven't fixed the evidence yet.
    //System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForDomain();
    // Create a new Evidence that include the MyComputer zone
    var replacementEvidence = new System.Security.Policy.Evidence();
    replacementEvidence.AddHostEvidence(new System.Security.Policy.Zone(System.Security.SecurityZone.MyComputer));
    // Replace the current AppDomain's evidence using reflection
    var currentAppDomain = System.Threading.Thread.GetDomain();
    var securityIdentityField = currentAppDomain.GetType().GetField("_SecurityIdentity", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
    securityIdentityField.SetValue(currentAppDomain,replacementEvidence);
    // Now it works.
    System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForDomain();
