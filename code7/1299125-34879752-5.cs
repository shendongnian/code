	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Security.Cryptography;
	using System.Runtime.InteropServices.WindowsRuntime;
	using System.Runtime.InteropServices;
	using System.IO;
	namespace EncryptDecryptApplication
	{
		internal class Program
		{
			private static void Main(string[] args)
			{
				//Text to encrypt
				string plaintext = "Text to encrypt and decrypt!";
				// Password
				const string password = "password";
				// Constants used in cryptography functions
				const string MS_ENH_RSA_AES_PROV = "Microsoft Enhanced RSA and AES Cryptographic Provider";
					//Name of provider. Same as "Microsoft AES Cryptographic Provider".
				const byte PROV_RSA_AES = 24; //Type of provider
				const string KeyContainer = null;
					//Name of the key container to be used, if NULL then a default key container name is used. Must be a null-terminated string.
				const uint ALG_CLASS_HASH = (4 << 13); //32768 = 4*2^13; //Samma tror jag för alla hashalgoritmer
				const uint ALG_TYPE_ANY = (0); //Samma tror jag för alla hashalgoritmer
				const uint ALG_SID_SHA_256 = 12;
					//ALG_SID_MD5 = 3, ALG_SID_SHA = 4, ALG_SID_SHA_256 = 12, ALG_SID_SHA_384 = 13, ALG_SID_SHA_512 = 14
				const uint CALG_SHA_256 = (ALG_CLASS_HASH | ALG_TYPE_ANY | ALG_SID_SHA_256);
				const int ALG_CLASS_DATA_ENCRYPT = 24576;
				const int ALG_TYPE_BLOCK = 1536; //used in all types of AES, and in RC2
				const int ALG_SID_AES_256 = 16; //ALG_SID_AES_128 = 14, ALG_SID_AES_192 = 15, ALG_SID_AES_256 = 16
				const int CALG_AES_256 = (ALG_CLASS_DATA_ENCRYPT | ALG_TYPE_BLOCK | ALG_SID_AES_256);
				const int ENCRYPT_ALGORITHM = CALG_AES_256;
				// Obtain handle to Cryptographic Service Provider (CSP)
				string ProviderCSP = MS_ENH_RSA_AES_PROV + null;
					//name of the CSP to be used. Must be a null-terminated string.
				IntPtr CSPhandle = new IntPtr();
				Crypt32.CryptAcquireContext(ref CSPhandle, KeyContainer, ProviderCSP, PROV_RSA_AES, 0);
				//Create hash object
				IntPtr handleHashObj = new IntPtr();
				Crypt32.CryptCreateHash(CSPhandle, CALG_SHA_256, IntPtr.Zero, 0, ref handleHashObj);
				//Hash password
				byte[] pwByteArray = Encoding.Unicode.GetBytes(password);
				uint pwByteAmt = (uint) ASCIIEncoding.Unicode.GetByteCount(password);
				Crypt32.CryptHashData(handleHashObj, pwByteArray, pwByteAmt, 0);
				//Dervie session key from the hashed password
				IntPtr handleSessionKey = new IntPtr();
				Crypt32.CryptDeriveKey(CSPhandle, ENCRYPT_ALGORITHM, handleHashObj, 0, ref handleSessionKey);
				//CryptEncrypt iteration no 1 - Obtain buffer size (output ByteAmt_Itr1)
				byte[] byteArray = new byte[2*plaintext.Length*sizeof (char)];
				System.Buffer.BlockCopy(plaintext.ToCharArray(), 0, byteArray, 0, byteArray.Length/2);
				uint byteAmt_Itr1 = (uint) byteArray.Length; //No of bytes, i.e. the size, of the plaintext.
				uint bufferSize_Itr1 = byteAmt_Itr1; //Set buffer size to input data size for now
				Crypt32.CryptEncrypt(handleSessionKey, IntPtr.Zero, 1, 0, null, ref byteAmt_Itr1, 0);
				//CryptEncrypt iteration no 2 - Encryption
				uint byteAmt_Itr2 = (uint) byteArray.Length; //No of bytes, i.e. the size, of the plaintext.
				uint bufferSize_Itr2 = byteAmt_Itr1;
					//Output from iteration no 1 - size of output data, i.e. correct buffer size
				Crypt32.CryptEncrypt(handleSessionKey, IntPtr.Zero, 1, 0, byteArray, ref byteAmt_Itr2, bufferSize_Itr2);
				Console.WriteLine("Encrypted: " + Encoding.Default.GetString(byteArray));
				// Text encrypted as byteArray, try to decrypt it! //
				byte[] byteArray2 = new byte[byteArray.Length];
				byteArray.CopyTo(byteArray2, 0);
				//CryptDecrypt - with input from CryptEncrypt".
				Console.WriteLine(Crypt32.CryptDecrypt(handleSessionKey, IntPtr.Zero, 1, 0, byteArray2, ref byteAmt_Itr2));
			   
				//Convert decrypted byte array to string
				string decryptedText = Encoding.Unicode.GetString(byteArray2).Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries)[0];
				//char[] chars = new char[byteArray.Length / sizeof(char)];
				//System.Buffer.BlockCopy(byteArray, 0, chars, 0, byteArray.Length);
				//string decryptedText = new string(chars);
				Console.WriteLine("Decrypted: " + decryptedText);
			}
		}
		public class Crypt32
		{
			[DllImport("advapi32.dll", SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool CryptAcquireContext(
				ref IntPtr hProv,
				string pszContainer,
				string pszProvider,
				uint dwProvType,
				uint dwFlags);
			[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool CryptCreateHash(
				IntPtr hProv,
				uint algId,
				IntPtr hKey,
				uint dwFlags,
				ref IntPtr phHash);
			[DllImport("advapi32.dll", SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool CryptHashData(
				IntPtr hHash,
				byte[] pbData,
				uint dataLen,
				uint flags);
			[DllImport("advapi32.dll", SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool CryptDeriveKey(
				IntPtr hProv,
				int Algid,
				IntPtr hBaseData,
				int flags,
				ref IntPtr phKey);
			[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool CryptEncrypt(
				IntPtr hKey,
				IntPtr hHash,
				int Final,
				uint dwFlags,
				byte[] pbData,
				ref uint pdwDataLen,
				uint dwBufLen);
			[DllImport("advapi32.dll", SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool CryptDecrypt(
				IntPtr hKey,
				IntPtr hHash,
				int Final,
				uint dwFlags,
				byte[] pbData,
				ref uint pdwDataLen);
		}
	}
