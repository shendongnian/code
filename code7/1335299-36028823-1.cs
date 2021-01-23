    public class MyForm
    {	
    	private string[] _sourceFiles;
    	
    	private void browseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog diagBrowser = new FolderBrowserDialog();
            diagBrowser.Description = "Select a folder which contains files needing combined...";
    
            // Default folder, altered when the user selects folder of choice 
            string selectedFolder = @"C:\";
            diagBrowser.SelectedPath = selectedFolder;
    
            // initial file path display
            folderPath.Text = diagBrowser.SelectedPath;
    
            if (DialogResult.OK == diagBrowser.ShowDialog())
            {
                // Grab the folder that was chosen
                selectedFolder = diagBrowser.SelectedPath;
                folderPath.Text = diagBrowser.SelectedPath;
    
                _sourceFiles = Directory.GetFiles(selectedFolder, "*.doc");            
            }
        }
    
        private void combineButton_Click(object sender, EventArgs e)
        {
            if (_sourceFiles != null && _sourceFiles.Length > 0)
            {
        		string outputFileName = (@"C:\Test\Merge\Combined.docx");
        		MsWord.Merge(_sourceFiles, outputFileName, true);
    	    	// Message displaying how many files are combined. 
        		MessageBox.Show("A total of " + documentFolder.Length.ToString() + " documents have been merged", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
