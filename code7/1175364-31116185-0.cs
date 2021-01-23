        public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            XDocument xdoc = XDocument.Load("C:\\Users\\edvazubi\\Desktop\\ZM05.2015.xml");
            StringBuilder csv = new StringBuilder();
            foreach (XElement datarow in xdoc.Root.XPathSelectElements("instance/dataset/datarow"))
            {
             
                string knre1 = datarow.Elements("element").Where(i => i.Attribute("id").Value.Contains("knre1")).First().Value;
                string knre2 = datarow.Elements("element").Where(i => i.Attribute("id").Value.Contains("knre2")).First().Value;
                string betrag = datarow.Elements("element").Where(i => i.Attribute("id").Value.Contains("betrag")).First().Value;
                
                csv.AppendLine(knre1 + "," + knre2 + "," + betrag + "L");
            }
            File.WriteAllText("C:\\Users\\edvazubi\\Desktop\\CSVFile.csv", csv.ToString());
