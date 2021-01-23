			var i = 0;
			using (var zipFile = new ZipFile(""))
			{
				var factory = new ZipEntryFactory();
				
				while (reader.Read() && !reader.IsDBNull(1))
				{
					byte[] BytesData = (byte[])reader["PDF_DATA"];
					zipFile.Add(new DbFileSource(BytesData), "file-" + i);
					i++;
				}
			}
