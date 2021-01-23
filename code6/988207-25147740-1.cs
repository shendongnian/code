    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        int classRPM;
        int fanRPM;
        using (Fanrpm ds = new Fanrpm(....)
        {
            DataTable dt = ds.dataset.Tables[0];
            // Get and convert the value in the field named ClassRPM (assuming is a string)
            classRPM = Convert.ToInt32(dt.Rows[0].Field<string>("ClassRPM"));
            // Now check if the textbox contains a valid number
            if(!Int32.TryParse(txfanrpm.Text, out fanRPM))
            {
                MessageBox.Show("Not a number....");
                return;
            }
            // Start your logic
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
