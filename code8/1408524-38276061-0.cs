        public partial class Form1 : Form
    {
    public void saveProject()
    {
    NewProject proj22 = new NewProject(); //Create new with emtry string
    proj22.SchemaPath = "cfasf"; //Dow whatever you want to the string
    proj = proj22; //Set it equal to the class you havel already played with the string
    XmlDocument doc = new XmlDocument();
    XmlNode root = doc.CreateNode(XmlNodeType.Element, "testXml", null);
    XmlElement schemaPath = doc.CreateElement("Schema");
    schemaPath.SetAttribute("Path", proj.schemaPath);
    root.AppendChild(schemaPath);
    }
