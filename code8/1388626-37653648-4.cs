    private bool modifySQLFile(String file) {
      // given source file, let´s elaborate target file name
      String targetFile = Path.Combine(
        Path.GetDirectoryName(file),
        String.Format("{0}{1}.sql", 
          Path.GetFileNameWithoutExtension(file), 
          textBox1.Text));
      // In case you want a back up 
      //TODO: given source file name, elaborate back up file name 
      //String backUpFile = Path.Combine(...); 
    
      // Check (validate) before processing: do not override existing files
      if (File.Exists(targetFile)) 
        return false;
      //TODO: what if back up file exists? Should we override it? skip?  
    
      // if line doesn't start with SQL commentary -- 
      // and contains a variable, substitute the variable with its value 
      var target = File
        .ReadLines(file)
        .Select(line => (!line.StartsWith("--") && line.Contains(Variable)) 
           ? line.Replace(Variable, textBox2.Text)
           : line);
     
      // write modified above lines into file
      File.WriteAllLines(targetFile, target);
      // In case you want a back up 
      // Move file to backup
      //File.Move(file, backUpFile); 
     
      return true;  
    }
