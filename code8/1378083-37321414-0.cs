    public static void SaveMyFile(RichTextBox rtb)
        {
            // Create a SaveFileDialog to request a path and file name to save to.
            SaveFileDialog saveLog = new SaveFileDialog();
            // Initialize the SaveFileDialog to specify the RTF extention for the file.
            saveLog.DefaultExt = "*.rtf";
            saveLog.Filter = "RTF Files|*.rtf"; //You can do other extensions here.
            // Determine whether the user selected a file name from the saveFileDialog.
            if (saveLog.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveLog.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                try
                {
                    rtb.SaveFile(saveLog.FileName);
                }
                catch 
                {
                    MessageBox.Show("Error creating the file.\n Is the name correct and is enough free space on your disk\n ?");
                }
                MessageBox.Show("Logfile was saved successful.");
            }
        }
