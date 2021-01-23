    public void OpenFile()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
        if (openFileDialog.ShowDialog() && File.Exists(openFileDialog.FileName))
        {
            // Read all the lines from the file and store them in an array.
            var lines = File.ReadAllLines(openFileDialog.FileName);
    
            // Sanity check: there must be at least 3 lines.
            if (lines.Length < 3)
                System.Windows.MessageBox.Show("Error: not enough lines in file: " + openFileDialog.FileName);
            else
            {
                InvoiceNumbertxt.Text = lines[0];
                InvoiceDatetxt.Text = lines[1];
                DueDatetxt.Text = lines[2];
                foreach (var l in lines.Skip(3).Take(6))
                    PersonInfolst.Items.Add(l);    
                // I am assuming that the `ItemProperties` follow, as groups of 3 lines,
                // consisting of `Item`, `Description`, `Publisher`
                for (var i = 9; i + 2 < lines.Length; i += 3)
                {
                    Items.Add(new ItemProperties { 
                        Item = lines[i],
                        Description = lines[i + 1],
                        Publisher = lines[i + 2]
                    });
                }
            }
        }
    }
   
