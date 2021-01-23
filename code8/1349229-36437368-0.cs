    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
    {
        if(saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            List<string> appendLines = new List<string>()
            {
                "one string",
                "two string"
            };
    
            File.AppendAllLines(saveFileDialog.FileName, appendLines);
        }
    }
