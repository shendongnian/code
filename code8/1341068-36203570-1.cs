    if(words[6] == "no") 
    {
       System.Drawing.Color myColor = System.Drawing.ColorTranslator.FromHtml(words[..]);
       foreach(Label l in Labels)
       {
           l.BackColor = myColor;
       }
    }  
