    public partial class BindXmlToGridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XDocument doc = this.LoadXmlDoc("input.xml");
    
            List<Data> gridView1DS = this.GetData(doc, 0);
    
            TicketViewURG.DataSource = gridView1DS;
            TicketViewURG.DataBind();
        }
    
        private List<Data> GetData(XDocument doc,int ticketIndex)
        {
            var list = new List<Data>();
            var d = new Data();
    
            XElement element = doc.Elements("SupportTickets").Elements().ElementAt(ticketIndex);
    
            d.TimeDate = element.Attribute("Time.Date").Value;
            d.Reference = element.Element("Reference").Value;
            d.StoreID = element.Element("StoreID").Value;
            d.Department = element.Element("Department").Value;
            d.completeStatus = element.Element("completeStatus").Value;
            d.ActionRequired = element.Element("ActionRequired").Value;
    
            list.Add(d);
    
            return list;
        }
    
        private XDocument LoadXmlDoc(string fileName)
        {
            XDocument xmlDoc = XDocument.Load(Server.MapPath("~/App_Data/" + fileName));
            return xmlDoc;
        }
    }
    
    public class Data
    {
        public string TimeDate { get; set; }
        public string Reference { get; set; }
        public string StoreID { get; set; }
        public string Contact { get; set; }
        public string Department { get; set; }
        public string Description { get; set; }
        public string ActionRequired { get; set; }
        public string completeStatus { get; set; }
        public string ID { get; set; }
    }
