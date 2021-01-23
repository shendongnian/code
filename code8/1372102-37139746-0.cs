        Disposable.Using(
                () => new PasswordDeriveBytes(PasswordConstants.CryptoKey, null),
                password => Disposable.Using(
                    () => new RijndaelManaged(),
                    symmetricKey =>
                        {
                            symmetricKey.Mode = CipherMode.CBC; // ← this causes an issue, and also the fact that I made a **code block** here
                            return Disposable.Using(
                                () => symmetricKey.CreateEncryptor(password.GetBytes(PasswordConstants.KeySize/8), Encoding.ASCII.GetBytes(PasswordConstants.Cipher)),
                                encryptor => encryptor);
                        }
                    ));
