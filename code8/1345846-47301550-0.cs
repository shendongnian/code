    using (WordprocessingDocument doc = WordprocessingDocument.Open(docInByteArray, isEditable: true))
	{
		Settings settings = doc.MainDocumentPart.DocumentSettingsPart.Settings;
		OpenXmlElement openXmlElement = null;
		foreach (OpenXmlElement element in settings.ChildElements)
		{
			if (element is MailMerge mailMerge)
			{
				mailMerge.Query.Val = "SELECT * FROM " + csvPath;
				mailMerge.DataSourceObject.Remove();
			}
			else if (element is AttachedTemplate)
			{
				openXmlElement = element;
			}
		}
		if (openXmlElement != null)
		{
			openXmlElement.Remove();
		}
		doc.Save();
	}
