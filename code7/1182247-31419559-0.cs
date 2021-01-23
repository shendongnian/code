    using (StreamReader reader = new StreamReader(path))
    {
        var fs = reader.BaseStream;
        string password = "<password for the PFX>";
        Pkcs12Store store = new Pkcs12Store(fs, passWord.ToCharArray());
        
       foreach (string n in store.Aliases)
       {
           if (store.IsKeyEntry(n))
           {
               AsymmetricKeyEntry asymmetricKey = store.GetKey(n);
        
               if (asymmetricKey.Key.IsPrivate)
               {
                   ECPrivateKeyParameters privateKey = asymmetricKey.Key as ECPrivateKeyParameters;
               }
           }
       }
    }
