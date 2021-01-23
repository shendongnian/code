    namespace WinForms_CSharp
    {
        public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
            }
            public  List<APISAVE> list = null;
            private void Form2_Load(object sender, EventArgs e)
            {
                list = new List<APISAVE>();
                if (File.Exists(Application.StartupPath + "\\data.xml"))
                {
                    var doc = XDocument.Load("data.XML");
                    foreach (XElement element in doc.Descendants("APISAVE"))
                    {
                        list.Add(new APISAVE() { ID = element.Element("ID").Value, APIKEY = element.Element("APIKEY").Value, VCODE = element.Element("VCODE").Value });
                    }
                }
            }
        
            private void button1_Click(object sender, EventArgs e)
            {
                try
                {
                    APISAVE info = new APISAVE();
                    info.APIKEY = txtAPI.Text;
                    info.VCODE = txtVerC.Text;
                    info.ID = info.ID;
                    list.Add(info);
                    APISAVE.SaveData(list, "data.XML");
    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }       
        } // end of Form2 class
    
        public class APISAVE
        {
            private string id;
            private string APIkey;
            private string VCode;
    
            public string ID
            {
                get { return id; }
                set { id = Guid.NewGuid().ToString(); }
            }
    
            public string APIKEY
            {
                get { return APIkey; }
                set { APIkey = value; }
            }
    
            public string VCODE
            {
                get { return VCode; }
                set { VCode = value; }
    
            }
    
            public static void SaveData(List<APISAVE> list, string Filename)
            {
                File.Delete(Filename);
                XmlSerializer sr = new XmlSerializer(list.GetType());
                TextWriter writer = new StreamWriter(Filename, true);
                sr.Serialize(writer, list);
                writer.Close();
            }
        }
    }
