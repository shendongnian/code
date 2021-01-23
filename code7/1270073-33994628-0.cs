    public partial class Form1 : Form
    {
        List<List<byte[]>> _Z_ext = new List<List<byte[]>>();
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadB_Click(object sender, EventArgs e)
        {
            using (var stream = System.IO.File.OpenRead("Z.xml"))
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<List<byte[]>>));
                _Z_ext = (List<List<byte[]>>)serializer.Deserialize(stream);
            }
        }
        private void SaveB_Click(object sender, EventArgs e)
        {
            // Create some data
            byte[] b1 = new byte[2] { 64, 65 };
            List<byte[]> l1 = new List<byte[]>();
            l1.Add(b1);
            _Z_ext.Add(l1);
            byte[] b2 = new byte[2] { 66, 67 };
            List<byte[]> l2 = new List<byte[]>();
            l2.Add(b2);
            _Z_ext.Add(l2);
            using (var stream = System.IO.File.Create("Z.xml"))
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<List<byte[]>>));
                serializer.Serialize(stream, _Z_ext);
            }
        }
    }
