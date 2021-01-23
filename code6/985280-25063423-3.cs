        string defImage = (new System.Uri(System.Reflection.Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
        string imageDir = Path.GetDirectoryName(defImage);
        string fullPath = Path.Combine(imageDir, @"./Images/DefaultImage4.jpg");
        string path = string.Empty;
        if (accView.Rows[e.RowIndex].Cells[10].Value != null)
            path = accView.Rows[e.RowIndex].Cells[10].Value.ToString();
 
        //Syntax Error on line below for invalid arguments.      
        if (string.IsNullOrEmpty(path))
        {
            //set the default path
            path = fullPath;
        }
        //Syntax Error on line below for invalid arguments.       
        accPictureBox.Image = Image.FromFile(path, true)
