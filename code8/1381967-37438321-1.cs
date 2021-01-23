           public Form1()
           {
               InitializeComponent();            
               XmlDocument doc = new XmlDocument(); 
               string path = "c:\\temp\\Event.xml"; 
               doc.Load(path); 
               string nameOfEvent = doc.SelectSingleNode("/Event/Event_Name").InnerText; 
               eventName.Text = nameOfEvent;
           }
