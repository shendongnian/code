    string scannerInput = "";
    private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if ((int)e.KeyChar == 13)
        {
            listBox1.Items.Add(scannerInput );
            scannerInput = "";
        }
        else scannerInput += e.KeyChar.ToString();
    }
