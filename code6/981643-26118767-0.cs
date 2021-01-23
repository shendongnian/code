        CX509ExtensionEnhancedKeyUsage eku = new CX509ExtensionEnhancedKeyUsage();
        eku.InitializeEncode(cp_oids);
        eku.Critical = false;
        CX509AttributeExtensions InitExt = new CX509AttributeExtensions();
      //  Add the extension objects into an IX509Extensions collection.
        CX509Extensions ext1= new CX509Extensions();
        ext1.Add((CX509Extension)eku);
