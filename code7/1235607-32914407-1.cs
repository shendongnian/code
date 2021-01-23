    public class ShellViewModel : INotifyPropertyChanged
        {
            public string DisplayName { get; set; }
            private TestXmlData _resultData;
            public TestXmlData ResultData
            {
                get { return _resultData; }
                set
                {
                    _resultData = value;
                    OnPropertyChanged("ResultData");
                }
            }
    
            public void OnPropertyChanged(string name)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
    
            public ShellViewModel()
            {
                DisplayName = "Shell Window";
            }
    
            public void CreateObject()
            {
                String xmlData = "<TestXmlData><Id>88</Id><Name>What a name</Name></TestXmlData>";
                if (ResultData == null) { ResultData = new TestXmlData(); }
                XmlSerializer oXmlSerializer = new XmlSerializer(ResultData.GetType());
                ResultData = (TestXmlData)oXmlSerializer.Deserialize(new StringReader(xmlData));
                // at this point the debugger shows that the ResultData is correctly filled, 
                // the Name is definitely not empty
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
