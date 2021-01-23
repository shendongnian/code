	using System;
	using System.Text;
	using System.Security.Cryptography;
	using System.IO;
	namespace AESExample
	{
		class Program
		{
			static void Main(string[] args)
			{
				byte[] toEncrypt = Encoding.UTF8.GetBytes("Encrypted Text");
				byte[] key = Encoding.UTF8.GetBytes("password");
				String encrypted = Convert.ToBase64String(EncryptAES(toEncrypt, key));
			}
			public static byte[] EncryptAES(byte[] data, byte[] key)
			{
				using(RijndaelManaged algo = new RijndaelManaged())
				{
					algo.GenerateIV();
					algo.Mode = CipherMode.CBC;
					algo.Padding = PaddingMode.Zeros;
					byte[] saltBuffer = new byte[16];
					RNGCryptoServiceProvider saltGenerator = new RNGCryptoServiceProvider();
					saltGenerator.GetBytes(saltBuffer);
					Rfc2898DeriveBytes PBKDF2 = new Rfc2898DeriveBytes(key, saltBuffer, 1000);
					key = PBKDF2.GetBytes(32);
					ICryptoTransform cipher = algo.CreateEncryptor(key, algo.IV);
					using(MemoryStream ms = new MemoryStream())
					{
						ms.Write(algo.IV, 0, algo.IV.Length);
						ms.Write(saltBuffer, 0, saltBuffer.Length);
						using(CryptoStream cs = new CryptoStream(ms, cipher, CryptoStreamMode.Write))
						{
							using(StreamWriter sw = new StreamWriter(cs))
							{
								sw.Write(Encoding.UTF8.GetString(data).ToCharArray());
							}
						}
						return ms.ToArray();
					}
				}
			}
		}
	}
