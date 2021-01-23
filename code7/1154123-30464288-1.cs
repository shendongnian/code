    string[] file1 = System.IO.File.ReadAllLines("file1.txt");
    string[] file2 = System.IO.File.ReadAllLines("file2.txt");
    string[] file3 = System.IO.File.ReadAllLines("file3.txt");
    HashSet<string> missingFromTwo = new HashSet<string>(file2);
    HashSet<string> missingFromThree = new HashSet<string>(file3);
    //this line will remove all etries in file1 from file2,
    //hence file2 will remain with entries that do not exist
    //in file one.
    missingFromTwo.ExceptWith(file1);
    //this line will do the same with file3.
    missingFromThree.ExceptWith(file1);
    StringBuilder FinalResult = new StringBuilder();
    FinalResult.AppendLine("emails from file 2 that need to be added to file1:");
    FinalResult.Append(String.Join(Environment.NewLine, missingFromTwo.ToArray()));
    FinalResult.AppendLine("emails from file 3 that need to be added to file1:");
    FinalResult.Append(String.Join(Environment.NewLine, missingFromThree.ToArray()));
    System.IO.File.WriteAllText("Master.txt", FinalResult.ToString());
