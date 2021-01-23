    public class Entityobject
    {
        private Document _document = Document.EmptyDocument;
        public Document document
        {
        	get
    		{
    			return _document;
			}
			set
			{
				_document = value;
			}
		}
        private int? _randomint = 0;
        public int? randomint
        {
        	get
    		{
    			return _randomint;
			}
			set
			{
				_randomint = value;
			}
		}
        private string _randomstr = String.Empty;
        public string randomstr
        {
        	get
    		{
    			return _randomstr;
			}
			set
			{
				_randomstr = value;
			}
		}
    }
