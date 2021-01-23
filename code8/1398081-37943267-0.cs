    while ((line = m_readFile2.ReadLine()) != null)
    { 
       string[] values = line.Split('\t');
       // insert check for values.Length here to avoid index out of bounds exception
       values[3]= "High";  
       string newLine = string.Empty;
       for(int i=0;i<values.Length;i++)
       {
           newline+=values[i] + '\t';
       }
       newline.TrimEnd("\t");
       // write new line to file here
    }
