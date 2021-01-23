    private void chkFord_CheckedChanged(object sender, EventArgs e)
    {
        if (chkFord.Checked)
        {
            // you have it working ...
        }
        else
        {
            for (int x = lstCarMakes.Items.Count - 1; x >= 0; x-- )
            {
                string car = lstCarMakes.Items[x].ToString();
                if(car.IndexOf("Ford", StringComparison.InvariantCultureIgnoreCase) >= 0)
                   lstCarMakes.Items.RemoveAt(x);
            }
        }
    }
