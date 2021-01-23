    string line;
    List<product> promotions = new List<product>();
    // Read the file and display it line by line.
    System.IO.StreamReader file = 
        new System.IO.StreamReader(@"c:\yourFile.txt");
    while((line = file.ReadLine()) != null)
    {
        string[] words = line.Split(',');
        if(words.length == 4)
        {
            promotions.Add(new Promotion(words[0],words[1],words[2],words[3]));
        }
        else
        {
            promotions.Add(new product(words[0],words[1],words[2]));
        }
    }
    file.Close();
