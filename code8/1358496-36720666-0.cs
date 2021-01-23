    using System.IO;    
    (...)
    
    static void Main(string[] args)
    {
            
        string fileName = @"C:\Users\Nate\Documents\Visual Studio 2015\Projects\Chapter 15\Chapter 15 Question 3\Chapter 15 Question 3\TextFile1.txt";
        string[] lines = File.ReadAllLines(fileName);
            
        for (int i = 0; i< lines.Length; i++)
        {
            lines[i] = string.Format("{0} {1}", i + 1, lines[i]);
        }
        File.WriteAllLines(fileName, lines);
    }
