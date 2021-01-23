            Encoding utf8 = Encoding.UTF8;
			byte[] data_tmp = new byte[] { 1, 2, 3, 4 };
			String filename = "filename.txt";
			String text = "Some metadata........" + Environment.NewLine;
			System.IO.File.WriteAllText(
				System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), filename), text, utf8);
			using (var stream = new FileStream(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), filename), FileMode.Append))
			{
				IEnumerable<byte[]> bytesToStringedInUtf8 = data_tmp.Select(b => utf8.GetBytes(((int)b).ToString()));
				foreach (byte[] byteToStringedInUtf8 in bytesToStringedInUtf8)
				{
					stream.Write(byteToStringedInUtf8, 0, byteToStringedInUtf8.Length);
				}
				stream.Close();
			}
