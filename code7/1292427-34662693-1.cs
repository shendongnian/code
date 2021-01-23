    private async void button1_Click(object sender, EventArgs e)
    {
        button1.Enabled = false;
        test thTest = new test();
        //I'd note that you really should pull out reading in this file from your UI code; 
        //it should be in a separate method, and it should also be reading 
        //the file asynchronously.
        string[] strings;
        try
        {
            strings = System.IO.File.ReadAllLines("C:\\users\\alex\\desktop\\test.txt");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return;
        }
        foreach (var line in strings)
        {
            var result = await thTest.DoWork(line);
            listBox1.Items.Add(result);
        }
        listBox1.Items.Add("Done");
    }
