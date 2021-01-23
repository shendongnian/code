    using System;
    using System.Web.UI;
    namespace Stackoverflow
    {
        public partial class Test : Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                    AddRow();
            }
            protected void btnAdd_Click(object sender, EventArgs e)
            {
                AddRow();
            }
            private void AddRow()
            {
                litTest.Text += "<tr><td><input type=\"text\" style=\"height: 19px;\"></td><td><input type=\"text\" style=\"height: 19px;\"></td><td><input type=\"text\" style=\"height: 19px;\"></td></tr>";
            }
        }
    }
