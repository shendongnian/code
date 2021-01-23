    using System.Security.Cryptography;
    ...
    var rng = new RNGCryptoServiceProvider();
    var bytes = new byte[128];
    rng.GetBytes(bytes);
