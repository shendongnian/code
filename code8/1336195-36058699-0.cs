    public bool Prompt = true;
    private void Form_Closing(object sender, EventArgs e)
    {
        if (Prompt)
        {
            MessageBox.Show("Data thingy...whatever");
        }
    }
