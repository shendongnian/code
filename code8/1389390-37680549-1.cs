    using System;
    using System.Collections.Generic;
    using System.IO; 
    using System.Linq;
    ...
    string fileName = "file.txt";
    int iInsertAtLineNumber = 2;
    string strTextToInsert = "Amudha";
    
    List<String> lines = File
      .ReadLines(strTextFileName)
      .ToList();
    
    if (lines.Count > iInsertAtLineNumber)
      lines.Insert(iInsertAtLineNumber, strTextToInsert);
    else
      lines.Add(strTextToInsert);
    
    File.WriteAllLines(fileName, lines);
