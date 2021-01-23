    test.xml:
    <?xml version="1.0" encoding="utf-8"?>
    <TwitterCards>
      <Card1>
        <Site> @_Paul</Site>
        <title> Schneider's </title>
        <image> "C:\\AAA.jpg" </image>
        <description>foo</description>
      </Card1>
    </TwitterCards>
    public partial class Form1 : Form, INotifyPropertyChanged
    {
        XmlDocument doc = new XmlDocument();
        XmlElement m_textElem1;
        XmlElement m_textElem2;
        XmlElement m_textElem3;
        public string TextElement1Content
        {
            get { return m_textElem1.InnerText; }
            set { m_textElem1.InnerText = value;  }
        }
        
        public string TextElement2Content
        {
            get { return m_textElem2.InnerText; }
            set { m_textElem2.InnerText = value; }
        }
        
        public string TextElement3Content
        {
            get { return m_textElem3.InnerText; }
            set { m_textElem3.InnerText = value; }
        }
        public Form1()
        {
            InitializeComponent();
            
            doc.Load("..\\..\\test.xml");
            m_textElem1 = doc.SelectSingleNode("TwitterCards/Card1/title") as XmlElement;
            m_textElem2 = doc.SelectSingleNode("TwitterCards/Card1/image") as XmlElement;
            m_textElem3 = doc.SelectSingleNode("TwitterCards/Card1/description") as XmlElement;
            
            textBox1.DataBindings.Add("Text", this, "TextElement1Content");
            textBox2.DataBindings.Add("Text", this, "TextElement2Content");
            richTextBox1.DataBindings.Add("Text", this, "TextElement3Content");
        }
 
         private void saveButton_Click(object sender, EventArgs e)
         {
             doc.Save("..\\..\\saved.xml");
         }
         public event PropertyChangedEventHandler PropertyChanged;
         public void NotifyPropertyChanged(string propName)
         {
             if (PropertyChanged != null )
             {
                 PropertyChanged(this, new PropertyChangedEventArgs(propName));
             }
         }
    }
