    using System;
    using System.Text;
    using System.Security.Cryptography;
    using System.Linq;
        
    public static class Program
    {
    	static RijndaelManaged aes = new RijndaelManaged(){
    		Mode = CipherMode.CFB,
    		BlockSize = 128,
    		KeySize = 128,
    		FeedbackSize = 128,
    		Padding = PaddingMode.None
    	};
    	
    	public static void Main(){
    		byte[] key = Encoding.UTF8.GetBytes("0123456789abcdef");
    		byte[] iv = Encoding.UTF8.GetBytes("1234567890abcdef");
    		byte[] encryptedBytes = new byte[]{0x76, 0x2b, 0x6d, 0xce, 0xa9, 0xc2, 0xa7, 0x46, 0x0d, 0xb7};
    		
    		// Custom pad the bytes
    		int padded;
    		encryptedBytes = PadBytes(encryptedBytes, aes.BlockSize, out padded);
    		
    		// Decrypt bytes
    		byte[] decryptedBytes = DecryptBytesAES(encryptedBytes, key, iv, encryptedBytes.Length);
    		
    		// Check for successful decrypt
    		if(decryptedBytes != null){
    			// Unpad
    			decryptedBytes = UnpadBytes(decryptedBytes, padded);
    			Console.Write("Decrypted: " + Encoding.UTF8.GetString(decryptedBytes));
    		}
    		
    	}
    	
    	// Just an elegant way of initializing an array with bytes
    	public static byte[] Initialize(this byte[] array, byte value, int length)
    	{
    		for (int i = 0; i < array.Length; i++)
    		{
    			array[i] = value;
    		}
    		return array;
    	}
    	
    	// Custom padding to get around the issue of how Go uses CFB mode without padding differently than C#
    	public static byte[] PadBytes(byte[] encryptedBytes, int blockSize, out int numPadded)
    	{
    		numPadded = 0;
    		
    		// Check modulus of block size
    		int mod = encryptedBytes.Length % blockSize;
    		if (mod != 0)
    		{
    			// Calculate number to pad
    			numPadded = blockSize - mod;
    			
    			// Build array
    			return encryptedBytes.Concat(new byte[numPadded].Initialize(0, numPadded)).ToArray();
    		}
    		else {
    			// No padding needed
    			return encryptedBytes;
    		}
    	}
    	public static byte[] UnpadBytes(byte[] decryptedBytes, int numPadded)
    	{
    		if(numPadded != 0)
    		{
    			byte[] unpaddedBytes = new byte[decryptedBytes.Length - numPadded];
    			Array.Copy(decryptedBytes, unpaddedBytes, unpaddedBytes.Length);
    			return unpaddedBytes;
    		}
    		else
    		{
    			return decryptedBytes;
    		}
    	}
    	
    	public static byte[] DecryptBytesAES(byte[] cipherText, byte[] Key, byte[] IV, int size)
    	{
    		byte[] array = new byte[size];
    		try{
    			aes.Key = Key;
    			aes.IV = IV;
    			ICryptoTransform transform = aes.CreateDecryptor(aes.Key, aes.IV);
    			using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(cipherText))
    			{
    				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read))
    				{
    					cryptoStream.Read(array, 0, size);
    				}
    			}
    		}
    		catch(Exception e){
    			return null;
    		}
    		return array;
    	}
    }
