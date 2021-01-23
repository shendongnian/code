    private void btnGetTotal_Click(object sender, EventArgs e)
        {
            try
            {
                lblPresent.Text = Convert.ToString(countpresent());
                lblAbsent.Text = Convert.ToString(countabsent());
                lblLeave.Text=Convert.ToString(countleave());
            }
            catch
            {
            }
        }
