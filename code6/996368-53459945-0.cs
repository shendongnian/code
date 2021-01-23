		private void ListData()
		{
			List<string> arrHeaders = new List<string>();
			List<Tuple<int, string, string>> attributes = new List<Tuple<int, string, string>>();
			Shell32.Shell shell = new Shell32.Shell();
			var strFileName = filepath;
			Shell32.Folder objFolder = shell.NameSpace(System.IO.Path.GetDirectoryName(strFileName));
			Shell32.FolderItem folderItem = objFolder.ParseName(System.IO.Path.GetFileName(strFileName));
			for (int i = 0; i < short.MaxValue; i++)
			{
				string header = objFolder.GetDetailsOf(null, i);
				if (String.IsNullOrEmpty(header))
					break;
				arrHeaders.Add(header);
			}
			// The attributes list below will contain a tuple with attribute index, name and value
			// Once you know the index of the attribute you want to get, 
			// you can get it directly without looping, like this:
			var Authors = objFolder.GetDetailsOf(folderItem, 20);
			for (int i = 0; i < arrHeaders.Count; i++)
			{
				var attrName = arrHeaders[i];
				var attrValue = objFolder.GetDetailsOf(folderItem, i);
				var attrIdx = i;
				attributes.Add(new Tuple<int, string, string>(attrIdx, attrName, attrValue));
				data.Add(string.Format("'{0}'='{1}'", attrName, attrValue));
			}
			Console.ReadLine();
		}
