		public static void PublishDocToSP()
		{
			var clientContext = GetClient();
			SP.Client.File file;
			var folderName = "DocLib";
			// Upload file
			{
				var fileName = @"C:\Users\user\Desktop\file.pdf";
				var folder = clientContext.Web.Folders.GetByUrl(clientContext.Url + '/' + folderName);
				var info = new FileCreationInformation
				{
					ContentStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read),
					Overwrite = false,
					Url = clientContext.Url + '/' + folderName + '/' + Path.GetFileName(fileName),
				};
				file = folder.Files.Add(info);
				// !!! I set some value for Title field, because in my case, Title column is Display Column of Sparqube Lookup Classic
				ListItem itemFile = file.ListItemAllFields;
				itemFile["Title"] = Path.GetFileName(fileName);
				itemFile.Update();
				clientContext.Load(itemFile);
				clientContext.ExecuteQuery();
			}
			// Add item in list and reference file in property. Not working!
			{
				var list = clientContext.Web.Lists.GetById(Guid.Parse("{F682C057-9715-4F1C-BE1E-D451803FF389}"));
				var itemCreateInfo = new ListItemCreationInformation()
				{
					//FolderUrl
					//LeafName
					//UnderlyingObjectType
				};
				var li = list.AddItem(itemCreateInfo);
				li["Title"] = "adfadfadfaf";
				// Set value for Lookup Classic with single value selection
				li["sqLookupClassic"] = new SP.Client.FieldLookupValue()
				{
					LookupId = file.ListItemAllFields.Id
				};
				// !!! OR
				// li["sqLookupClassic"] = string.Format( "{0};#{1}", file.ListItemAllFields.Id, file.ListItemAllFields["Title"] );
				// !!! If 'Allow multiple values' option is selected for Lookup classic, you should set value in the following way:
				//li["sqLookupClassic"] = string.Format( "{0};#{1};#{2};#{3}", item1.Id, item1["Title"], item2.Id, item2["Title"] );
				li.Update();
				clientContext.ExecuteQuery();
				var insertedId = li.Id;
			}
		}
