    using System.Security.Cryptography;
    using System.Text;
    
    namespace GrimoireTactics.Framework.Security
    {
        public enum ObfuscatorType
        {
            Encrypt,
            Decrypt
        }
        public class Obfuscator
        {
            private string _seed;
            private byte[] _hashedSeedBytes;
            private readonly SHA256Managed _hashingAlgorithm;
            public string Seed
            {
                get
                {
                    return _seed;
                }
                set
                {
                    this._seed = value;
                    SeedHash = GenerateHash(value);
                    this._hashedSeedBytes = GetBytes(SeedHash);
                }
            }
    
            public byte[] SeedBytes
            {
                get
                {
                    return _hashedSeedBytes;
                }
            }
    
            public string SeedHash { get; private set; }
    
            public Obfuscator(string seed)
            {
                this._hashingAlgorithm = new SHA256Managed();
                this.Seed = seed;
            }
    
    
            public byte[] Encrypt(byte[] data)
            {
                return Transform(data, ObfuscatorType.Encrypt);
            }
    
            public byte[] Encrypt(string data)
            {
                return Transform(GetBytes(data), ObfuscatorType.Encrypt);
            }
    
            public byte[] Decrypt(byte[] data)
            {
                return Transform(data, ObfuscatorType.Decrypt);
            }
    
            public byte[] Transform(byte[] bytes, ObfuscatorType type)
            {
                int passwordShiftIndex = 0;
                byte[] data = bytes;
                byte offset = 0;
                switch (type)
                {
                    case ObfuscatorType.Encrypt:
                        for (int i = 0; i < data.Length; i++)
                        {
                            byte currentByte = _hashedSeedBytes[passwordShiftIndex];
                            offset += (byte)(1 + currentByte); // Incrementing Offset
                            data[i] = (byte)(data[i] + currentByte + offset);
                            passwordShiftIndex = (passwordShiftIndex + 1) % _hashedSeedBytes.Length;
                        }
                        break;
                    case ObfuscatorType.Decrypt:
                        for (int i = 0; i < data.Length; i++)
                        {
                            byte currentByte = _hashedSeedBytes[passwordShiftIndex];
                            offset += (byte)(1 + currentByte); // Incrementing Offset
                            data[i] = (byte)(data[i] - currentByte - offset);
                            passwordShiftIndex = (passwordShiftIndex + 1) % _hashedSeedBytes.Length;
                        }
                        break;
                }
                return data;
            }
    
            public byte[] GetBytes(string data)
            {
                return Encoding.UTF8.GetBytes(data);
            }
    
            public byte[] GetBytes(string data, Encoding encoding)
            {
                return encoding.GetBytes(data);
            }
    
            public string GetString(byte[] data)
            {
                return Encoding.UTF8.GetString(data);
            }
    
            public string GetString(byte[] data, Encoding encoding)
            {
                return encoding.GetString(data);
            }
    
            public string GenerateHash(string text)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                byte[] hash = _hashingAlgorithm.ComputeHash(bytes);
                string hashString = string.Empty;
                for (int index = 0; index < hash.Length; index++)
                {
                    byte x = hash[index];
                    hashString += $"{x:x2}";
                }
                return hashString;
            }
        }
    }
