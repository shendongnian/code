    protected void Button2_Click(object sender, EventArgs e)
    {
        String a1 = FileUpload1.FileName;
        String ext1 = Path.GetExtension(a1);
        if (ext1 == ".txt")
        {
    
            System.IO.StreamReader reader = new System.IO.StreamReader(FileUpload1.FileContent);
            string text = reader.ReadToEnd();
    
            List<string> list = new List<string>(); //code for splitting 
            String[] words = text.Split();
            for (int i = 0; i < words.Length; i++)
            {
                list.Add(words[i]);
            }
            var textTobeShown = new List<string>();
            foreach (string word in words)
            {
    
                Char[] letters = word.ToCharArray();
                foreach (char letter in letters)
                {
    
                   textTobeShown.Add("<marquee>"+letter+"</marquee>");
               
                }
                   textTobeShown.Add("<marquee>" + word + "</marquee>");
            }
        //use <sep> for separating text
        hiddenLiteral.text=String.Join("<sep>",textTobeShown);
        //Call Our Javascript Function when updatePanel Update Fields Value
        scriptLiteral.Text=String.Concat("<script> DisplayText('",hiddenLiteral.ClientID,"','",displayLiteral.ClientID,"');  </script>");
        //updating our updatePanel
        updatePanel1.Update();
        }
    
    }
