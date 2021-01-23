    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Xml;
    using System.IO;
    
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) readxml();
            
        }
    
        private void readxml()
        {
            var xmldoc = new XmlDocument();
                    xmldoc.Load(Server.MapPath("contacts.xml"));
            var xmlnodes = xmldoc.GetElementsByTagName("Contact");
    
            repeater1.DataSource = xmlnodes;
            repeater1.DataBind();
    
            xmldoc = null;
        }
    
        protected void repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;
    
            var node = (XmlNode)e.Item.DataItem;  
            var txtName = (TextBox)e.Item.FindControl("txtName");
            txtName.Text = node.Attributes["name"].Value;
            var txtLstNumber = (TextBox)e.Item.FindControl("txtLstNumber");
            txtLstNumber.Text = node.Attributes["lastName"].Value;
        }
    
        protected void SaveButton_Click(object sender, EventArgs e)
        {
    
            var xmldoc = new XmlDocument();
            xmldoc.Load(Server.MapPath("contacts.xml"));
            var xmlnodes = xmldoc.GetElementsByTagName("Contact");
    
    
            for (var i = 0; i < repeater1.Items.Count; i++)
            {
                var item = repeater1.Items[i];
                var txtName = (TextBox)item.FindControl("txtName");
                var name =  txtName.Text ;
                var txtLstNumber = (TextBox)item.FindControl("txtLstNumber");
                var lastName = txtLstNumber.Text;
    
                var node = xmlnodes[i];
                node.Attributes["name"].Value = name;
                node.Attributes["lastName"].Value = lastName;
            }
    
            xmldoc.Save(Server.MapPath("contacts.xml"));
            xmldoc = null;
        }
    }
