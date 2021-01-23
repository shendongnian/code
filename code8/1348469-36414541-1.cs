    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (double value in File.ReadAllText("Sales.txt").Split(' ').Select((x) => (double.Parse(x))))
            {
                listBox1.Items.Add(value);
            }
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
