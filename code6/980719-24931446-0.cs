      string[] lines = File.ReadAllLines(filepath);
      Dictionary<string,int> pairs = new Dictionary<string,int>();
        
        for(int i=8;i<lines.Length;i++)
        {
            string[] pair = Regex.Replace(lines[i],"(\\s)+",";").Split(';');
            pairs.Add(pair[0],int.Parse(pair[1]));
        }
