    private int i;
        protected void btnStart_Click(object sender, EventArgs e)
        {
                i =   Int32.Parse(lblStart.Text);
                i++;
    
                lblStart.Text = i.ToString();
        }
