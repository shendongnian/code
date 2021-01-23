     protected void LinkButton1_Click(object sender, EventArgs e)
            {
                //Read More Link Button from Gridview on Click
                LinkButton lb = (LinkButton)sender;
                GridViewRow row = lb.NamingContainer as GridViewRow;
                //Finding the description Text Lable
                Label qst = row.FindControl("Label20") as Label;
                // Setting Link Button Text 
                lb.Text = (lb.Text == "Read More...") ? "Hide..." : "Read More...";
                //Swaping tooltip value to text and vices versa as Tooltip has all charecters
                string temp = qst.Text;
                qst.Text = qst.ToolTip;
                qst.ToolTip = temp;
            }
    protected bool SetVisibility(object Desc, int length)
            {
                return Desc.ToString().Length > length;
            }
