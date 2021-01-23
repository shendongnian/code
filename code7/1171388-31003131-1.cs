    public static class DESCryptoExtensions
    {
        // Mode = 0 encrypt, 1 decrypt
        public static ICryptoTransform CreateWeakEncryptor(this DESCryptoServiceProvider cryptoProvider, byte[] key, byte[] iv, int mode = 0)
        {
            // reflective way of doing what CreateEncryptor() does, bypassing the check for weak keys
            MethodInfo mi = cryptoProvider.GetType().GetMethod("_NewEncryptor", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] Par = { key, cryptoProvider.Mode, iv, cryptoProvider.FeedbackSize, mode };
            ICryptoTransform trans = mi.Invoke(cryptoProvider, Par) as ICryptoTransform;
            return trans;
        }
        public static ICryptoTransform CreateWeakEncryptor(this DESCryptoServiceProvider cryptoProvider)
        {
            return CreateWeakEncryptor(cryptoProvider, cryptoProvider.Key, cryptoProvider.IV);
        }
        public static ICryptoTransform CreateWeakDecryptor(this DESCryptoServiceProvider cryptoProvider, byte[] key, byte[] iv)
        {
            return CreateWeakEncryptor(cryptoProvider, key, iv, 1);
        }
        public static ICryptoTransform CreateWeakDecryptor(this DESCryptoServiceProvider cryptoProvider)
        {
            return CreateWeakDecryptor(cryptoProvider, cryptoProvider.Key, cryptoProvider.IV);
        }
    }
