    private int linesProcessed;  //Variable for keeping track of your line position
    private void ProcessFile( string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        if (linesProcessed != lines.Count())  //Make sure a new line was entered 
        {
            for (int i = linesProcessed ; i < lines.Count(); i++)
            {
                textBox1.AppendText(lines[i] + "\n") ;  
                linesProcessed += 1;
            }
        }
    }
    private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
    {
       ProcessFile("c:\\temp\\test.txt");  //your file name here
    }
