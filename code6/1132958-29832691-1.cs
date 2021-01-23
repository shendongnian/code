    string[] myTextFileLines = File.ReadAllLines(myTextFile);
    
    List<Race> myRaces = new List<Race>();
    for (int i = 0; i < myTextFileLines.Length; i += 4)
    {
        myRaces.Add(new Race()
                        {
                            Name = myTextFileLines[i].Substring(myTextFileLines[i].IndexOf(":") + 2),
                            Speed = Convert.ToInt32(myTextFileLines[i + 1].Substring(myTextFileLines[i + 1].IndexOf(":") + 2)),
                            Strength = Convert.ToInt32(myTextFileLines[i + 2].Substring(myTextFileLines[i + 2].IndexOf(":") + 2)),
                            Stamina = Convert.ToInt32(myTextFileLines[i + 3].Substring(myTextFileLines[i + 3].IndexOf(":") + 2)),
                        });
    }
    
    Console.WriteLine("Avg Speed: {0}", myRaces.Average(r => Convert.ToDouble(r.Speed)));
    Console.WriteLine("Avg Strength: {0}", myRaces.Average(r => Convert.ToDouble(r.Strength)));
    Console.WriteLine("Avg Stamina: {0}", myRaces.Average(r => Convert.ToDouble(r.Strength)));
    Console.ReadLine();
