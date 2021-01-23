		public static byte[] ReadFullStream(Stream st)
		{
			var lockTaken = false;
			try
			{
				Monitor.Enter(_lock, ref lockTaken);
				var size = 0;
				var continueRead = true;
				var buffer = (byte[])Array.CreateInstance(typeof(byte), 0x10000);				using (MemoryStream ms = new MemoryStream())
				while (continueRead)
				{
					size = st.Read(buffer, 0, buffer.Length);
					if (size > 0)
					{
						ms.Write(buffer, 0, size);
					}
					else
					{
						continueRead = false;
					}
				}
				return ms.ToArray();
			}
			finally
			{
				if (lockTaken) { Monitor.Exit(_lock); }
			}
		}
