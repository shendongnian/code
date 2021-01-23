	using (FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create))
	{
		using (CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write))
		{
			using (FileStream fsIn = new FileStream(inputFile, FileMode.Open))
			{
				int data;
				int test = 0;
				int total = fsIn.Length;
				while ((data = fsIn.ReadByte()) != -1)
				{
					cs.WriteByte((byte) data);
					test++;
					if (test % 10000 == 0)
					{
						backgroundWorker1.ReportProgress((int) (test * 100 / total));
					}
				}
			}
		}
	}
