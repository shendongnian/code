    object findText = "find me";
    int docc = wordfile.Paragraphs.Count;
    Range rng = wordfile.Paragraphs[docc].Range;
    rng.Find.ClearFormatting();
    if (rng.Find.Execute(ref findText,
    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,Type.Missing,
    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
    Type.Missing, Type.Missing)) 
     { 
      MessageBox.Show("Text found.");
     } 
    else 
    { 
     MessageBox.Show("Text not found.");
    } 
    rng.Select(); 
 
