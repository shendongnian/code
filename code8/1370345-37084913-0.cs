    private void btnEnter_Click(object sender, EventArgs e)
        {   
            if(!System.IO.File.Exists(txtExisting.Text + ".txt")
            {
                  MessageBox.Show("File not found");
                  return;
            }
            FileInfo file = new FileInfo(txtExisting.Text + ".txt");
            StreamReader stRead = file.OpenText();
            while (!stRead.EndOfStream)
            {
                listBox1.Items.Add(stRead.ReadLine()); 
            }  
        }
