    // data for example
    var data = new XElement("gamedata",
        new XElement("player", new XAttribute("name", "t0taln00b"),
            new XElement("score",
                new XAttribute("game", "bite your elbow"),
                new XAttribute("score", 9000),
                new XAttribute("progress", "19 %"))
            )
        );
    // set up encryption.
    // You probably will want to do this once at program startup and store Key and IV globally
    var rnd = new Random(12562);
    var keysize = 128;
    byte[]
        Key = new byte[keysize / 8],
        IV = new byte[keysize / 8];
    rnd.NextBytes(Key);
    rnd.NextBytes(IV);
 
    // lets encrypt
    using (Aes aes = new AesManaged() { Padding = PaddingMode.PKCS7, KeySize = keysize })
    {
        aes.Key = Key;
        aes.IV = IV;
        using (Stream file = new FileStream("save.xml.aes", FileMode.Create, FileAccess.Write))
        using (Stream encrypter = new CryptoStream(file, aes.CreateEncryptor(), CryptoStreamMode.Write))
            data.Save(encrypter);
    }
    //and decrypt
    using (Aes aes = new AesManaged() { Padding = PaddingMode.PKCS7, KeySize = keysize })
    {
        aes.Key = Key;
        aes.IV = IV;
        using (Stream file = new FileStream("save.xml.aes", FileMode.Open, FileAccess.Read))
        using (Stream decrypter = new CryptoStream(file, aes.CreateDecryptor(), CryptoStreamMode.Read))
        {
            var loaded = XElement.Load(decrypter);
            Console.WriteLine(loaded.ToString());
        }
    }
