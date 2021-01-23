    foreach (FileInfo file in files)
    {    
        string path = @"F:\UNI\Year 2\Tri 2\Software Engineering Methods\Coursework\Noogle system\Valid_Messages\";
        //reads the file contents
        using (StreamReader ReadMessage = new StreamReader(file.FullName))
        {
            String MessageContents = ReadMessage.ReadToEnd();
            //checks if the textwords are present in the file               
            foreach (string Keyword in textwords)
            {
                if (MessageContents.Contains(Keyword))
                {
                    path = @"F:\UNI\Year 2\Tri 2\Software Engineering Methods\Coursework\Noogle system\Quarantin_Messages\"
                    break;
                }
            }                 
        }
        // let the StreamReader close down before the copy  
        // don't need it anymore  
        try
        {
            File.Copy(file.FullName, path + file);
        }
        catch (IOException cannot_Move_File)
        {
            MessageBox.Show(cannot_Move_File.ToString());
        }           
    }
