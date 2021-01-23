    public abstract class HMAC : KeyedHashAlgorithm {
        new static public HMAC Create () {
            return Create("System.Security.Cryptography.HMAC");
        }
 
        new static public HMAC Create (string algorithmName) {
            return (HMAC) CryptoConfig.CreateFromName(algorithmName);
        }
        ...
    }
