     protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder SB = new StringBuilder();
            SB.Append("<script>");
            SB.Append("$(document).ready(function () {");
           
            // statements here
            SB.Append("alert('test');");
            SB.Append("});</script>");
            CodeInject.Text = SB.ToString();
        }
