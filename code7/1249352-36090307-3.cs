    public ActionResult SomeAction()
        {
                    string Key = "1234567890abcdef"; //key must have 16 chars, other wise you may get error "key size in not valid".
                    Password = "Secret";
                    Cryptography Crypt = new Cryptography();
                    EncryptedPassword = (string)Crypt.Crypt(CryptType.ENCRYPT, CryptTechnique.RIJ, Password, Key);
        }
