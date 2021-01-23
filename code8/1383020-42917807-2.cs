	using System;
	using System.IO;
	using System.Security.Cryptography;
	namespace TestAES_CFB
	{
		class Program
		{
			static byte[] AES_CFB_Encrypt(string plainText, byte[] Key, byte[] IV)
			{
				byte[] encrypted;
				using (Aes aes = Aes.Create())
				{
					aes.KeySize = 128; // 16 bytes
					aes.BlockSize = 128; // 16 bytes
					aes.Key = Key;
					aes.IV = IV;
					aes.Padding = PaddingMode.Zeros;
					aes.Mode = CipherMode.CFB;
					ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
					using (MemoryStream msEncrypt = new MemoryStream())
					{
						using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
						{
							using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
							{
								swEncrypt.Write(plainText);
							}
							encrypted = msEncrypt.ToArray();
						}
					}
				}
				return encrypted;
			}
			static string AES_CFB_Decrypt(byte[] cipherText, byte[] Key, byte[] IV)
			{
				string plaintext = null;
				using (Aes aes = Aes.Create())
				{
					aes.KeySize = 128; // 16 bytes
					aes.BlockSize = 128; // 16 bytes
					aes.Key = Key;
					aes.IV = IV;
					aes.Padding = PaddingMode.Zeros;
					aes.Mode = CipherMode.CFB;
					ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
					using (MemoryStream msDecrypt = new MemoryStream(cipherText))
					{
						using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
						{
							using (StreamReader srDecrypt = new StreamReader(csDecrypt))
							{
								plaintext = srDecrypt.ReadToEnd();
							}
						}
					}
				}
				return plaintext;
			}
			static void Main(string[] args)
			{
				const int AES_CFB_BLOCK_SIZE = 16;
				const int PLAINTEXT_SIZE = 7;
				//41413744443430333035394e36373038
				byte[] key = new byte[AES_CFB_BLOCK_SIZE] {0x41, 0x41, 0x37, 0x44, 0x44, 0x34, 0x30, 0x33, 0x30, 0x35, 0x39, 0x4e, 0x36, 0x37, 0x30, 0x38};
				//000102030405060708090A0B0C0D0E0F
				byte[] iv = new byte[AES_CFB_BLOCK_SIZE] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07,  0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F};
				//testabc = 74657374616263
				string plntxt = "testabc";
				using (Aes myAes = Aes.Create())
				{
					byte[] encrypted = AES_CFB_Encrypt(plntxt, key, iv);
					string decrypted  = AES_CFB_Decrypt(encrypted, key, iv);
					Console.WriteLine("Encrypted:  {0}", Convert.ToBase64String(encrypted));
					Console.WriteLine("Decrypted: {0}", decrypted);
					Console.ReadLine();
				}
			}
		}
	}
