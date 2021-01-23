    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        int classRPM;
        int fanRPM;
        using (Fanrpm ds = new Fanrpm(....)
        {
            DataTable dt = ds.dataset.Tables[0];
            classRPM = Convert.ToInt32(row[0].ToString());
            if(!Int32.TryParse(txfanrpm.Text, out fanRPM))
            {
                MessageBox.Show("Not a number....");
                return;
            }
            if (fanRPM >= classRPM)
            {
                MessageBox.Show(.....);
            }
            else if (fanRPM < classRPM)
            {
                MessageBox.Show(.......);
            }
        }
    }
