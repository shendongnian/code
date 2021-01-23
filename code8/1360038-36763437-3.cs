    static int count=0;// Global Variable declare somewhere at the top 
    
    protected void bttnAdd_Click(object sender, EventArgs e)
            {
                count++;
    
                if (count > 6)
                {
                    lblBet.Text = count.ToString();
                }
                else
                {
                    count = 0;
                }
            }
