	public class ProcessGuidHeader : MessageHeader
	{
		private string _attr;
		private string _headerName = "HeaderInfo";
		private string _elementName = "ProcType";
		private string _headerNamespace = "http://schemas.tempuri.fi/process/2016/04/";
		public ProcessGuidHeader(string attr)
		{
			_attr = attr;
		}
		public string Attr
		{
			get { return _attr; }
		} 
		public override string Name
		{
			get { return _headerName; }
		}
		public override string Namespace
		{
			get { return _headerNamespace; }
		}
		protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
		{
			writer.WriteElementString(_elementName, _attr);
		}
	}
