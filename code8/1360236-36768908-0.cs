        StreamWriter writer = new StreamWriter(
            @"C:\Users\Nate\Documents\Visual Studio 2015\Projects\Chapter 15\Chapter 15 Question 7\Chapter 15 Question 7\TextFile.txt");
        using (writer)
        {
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string myNewLine=line.Replace("start", "finish");
                    writer.WriteLine(myNewLine);
                }
            }
        }
    }
}
