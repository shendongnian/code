    private void button1_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();     
            System.Diagnostics.Debug.WriteLine("button clicked!");
        }
    
    Public Form1()
    {
      txtOn.Text = "test!";
    }
