    using (System.IO.StreamWriter writer =new System.IO.StreamWriter(path,false))
    {
        foreach (string[] line in Result)
        {
            writer.WriteLine(string.Join("\t", line)); 
        }
    }; 
