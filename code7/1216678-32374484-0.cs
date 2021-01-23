    public void Start()
    {
        theSourceFile = new FileInfo(Application.dataPath + "/puzzles.txt");
        ProcessFile(theSourceFile);
        // set theSourceFile to another file
        // call ProcessFile(theSourceFile) again
    }
    private void ProcessFile(FileInfo file)
    {
          
          if (file != null && file.Exists)
            reader = file.OpenText();
        if (reader == null)
        {
          Debug.Log("puzzles.txt not found or not readable");
        }
        else
        {
          while ((txt = reader.ReadLine()) != null)
            {
                Debug.Log("-->" + txt);
                completeText += txt + "\n";
             }
          
             _allFiles.Add(completeText);
        }
    }
