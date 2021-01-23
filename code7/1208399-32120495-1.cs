    using System;
    
    namespace WebApplication1
    {
        public partial class WebForm2 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                div1.Visible = false;
                div2.Visible = true;
                div3.Visible = false;
            }
            protected void Button2_Click(object sender, EventArgs e)
            {
                div1.Visible = true;
                div2.Visible = false;
                div3.Visible = false;
            }
            protected void Button3_Click(object sender, EventArgs e)
            {
                div1.Visible = false;
                div2.Visible = false;
                div3.Visible = true;
                Label1.Text = CheckBox1.Checked.ToString();
                Label2.Text = CheckBox2.Checked.ToString();
                Label3.Text = TextBox1.Text;
                Label4.Text = TextBox2.Text;
            }
            protected void Button4_Click(object sender, EventArgs e)
            {
                div1.Visible = false;
                div2.Visible = true;
                div3.Visible = false;
            }
        }
    }
