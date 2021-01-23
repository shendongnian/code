    public string MD5HashFile(string fn)
    {
        byte[] hash = MD5.Create().ComputeHash(File.ReadAllBytes(fn));
        return BitConverter.ToString(hash).Replace("-", "");
    }
    private void lblTitle_Load(object sender, EventArgs e)
    {
    }
    
    private void scanButton_Click(object sender, EventArgs e)
    {
        //Create a path to the textBox that holds the value of the file that is going to be scanned
        string path = txtFilePath.Text;
        //if there is something in the textbox to scan we need to make sure that its doing it.
        if (!File.Exists(path))
        {
                                // ... report problem to user.
          return;
            
        }
        else
        {
            MessageBox.Show("Scan Complete");
        }
        //Display the computed MD5 Hash in the path we declared earlier
        hashDisplay.Text = MD5HashFile(path);
    }
