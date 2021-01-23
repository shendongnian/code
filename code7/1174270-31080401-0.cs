    RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
    //var publicKey = PublicKey.GetPublicKey();
    provider.FromXmlString(
        "<RSAKeyValue>"+
            "<Modulus>CmZ5HcaYgWjeerd0Gbt/sMABxicQJwB1FClC4ZqNjFHQU7PjeCod5dxa9OvplGgXARSh3+Z83Jqa9V1lViC7qw==</Modulus>"+
            "<Exponent>AQAB</Exponent>"+
        "</RSAKeyValue>");
