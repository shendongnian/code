    private void btnEnter_Click(object sender, EventArgs e)
    {   
        try
        {
            FileInfo file = new FileInfo(txtExisting.Text + ".txt");
            StreamReader stRead = file.OpenText();
            while (!stRead.EndOfStream)
            {
                listBox1.Items.Add(stRead.ReadLine()); 
            }  
        }
        catch (FileNotFoundException ex)
        {
            // Handle exception
        }
    }
