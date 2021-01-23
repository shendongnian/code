	public class CustomXMLPartsRepository 
	{
        public MyDocumentMetaData Read()
        {
            var CustomXMLParts = Globals.ThisAddIn.Application.ActiveWorkbook.CustomXMLParts.SelectByNamespace("myNamespace");
            foreach (CustomXMLPart p in CustomXMLParts)
            {
                return MyDocumentMetaData.LoadFromXMLString(p.XML);
            }
            return null;
        }
			
        public void Write(MyDocumentMetaData data)
		{
			Globals.ThisAddIn.Application.ActiveWorkbook.CustomXMLParts.Add(data.ToXML());
		}
		
		private void clearNamespace(){
		    var CustomXMLParts = Globals.ThisAddIn.Application.ActiveWorkbook.CustomXMLParts.SelectByNamespace("myNamespace");
            foreach (CustomXMLPart p in CustomXMLParts)
            {
                p.Delete();
            }
		}
	}
