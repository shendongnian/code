    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Drawing;
    
    namespace test
    {
        public partial class page1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (Session["dynamicBtnSession"] != null)
                {
                    CreateDynamicButton((string)Session["dynamicBtnSession"]);
                }
            }
    
            protected void ddlLecturer_SelectedIndexChanged(object sender, EventArgs e)
            {
                placeHolder.Controls.Remove(FindControl("dynamicBtn"));
                lblOutput.Text = string.Empty;
                if (ddlLecturer.SelectedValue != "Select")
                {
                    Session["dynamicBtnSession"] = ddlLecturer.SelectedValue;
                    CreateDynamicButton(ddlLecturer.SelectedValue);
                }
                else
                {
                    Session["dynamicBtnSession"] = null;
                }
            }
    
            private void CreateDynamicButton(string val)
            {
                Button btn = new Button();
                btn.Height = 40;
                btn.Width = 120;
                btn.BackColor = Color.Gray;
                btn.ForeColor = Color.Black;
                btn.ID = "dynamicBtn";
                btn.Text = "Dynamic Button " + val;
                btn.Click += new EventHandler(btn_Click);
                placeHolder.Controls.Add(btn);
            }
    
            void btn_Click(object sender, EventArgs e)
            {
                lblOutput.Text = "You clicked " + ((Button)sender).Text;
            }
        }
    }
