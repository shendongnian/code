        public class PokemonStat
        {
            public int Hp { get; set; }
            public int Atk { get; set; }
            public int Def { get; set; }
            public int SpAtk { get; set; }
            public int SpDef { get; set; }
            public int Spe { get; set; }
        }
        public Class1()
        {
            var newPokemanData = new Dictionary<int, PokemonStat>();
            var fileNames = new string[] { "Hp.txt", "Atk.txt", "Def.txt", "SpAtk.txt", "SpDef.txt", "Spe.txt" }
            foreach (var fileName in fileNames)
            {
                var lineNumber = 0;
                using (var stream = new StreamReader(fileName))
                {
                    while (!stream.EndOfStream)
                    {
                        var singleStat = stream.ReadLine();
                        if (!newPokemanData.Keys.Contains(lineNumber))
                        {
                            newPokemanData.Add(lineNumber, new PokemonStat());
                        }
                   
                        switch(fileName)
                        {
                            case "Hp.txt":
                                newPokemanData[lineNumber].Hp = int.Parse(singleStat);
                                break;
                            case "Atk.txt":
                                newPokemanData[lineNumber].Atk = int.Parse(singleStat);
                                break;
                            case "Def.txt":
                                newPokemanData[lineNumber].Def = int.Parse(singleStat);
                                break;
                            case "SpAtk.txt":
                                newPokemanData[lineNumber].SpAtk = int.Parse(singleStat);
                                break;
                            case "SpDef.txt":
                                newPokemanData[lineNumber].SpDef = int.Parse(singleStat);
                                break;
                            case "Spe.txt":
                                newPokemanData[lineNumber].Spe = int.Parse(singleStat);
                                break;
                            default:
                                Console.WriteLine("Error");
                                break;
                        }
                        lineNumber++;
                   
                    }
                }
            }
            using (var unifiedStats = new StreamWriter("unifieldFile.txt"))
            {
                foreach (var line in newPokemanData.Keys)
                {
                    //write to a file
                    unifiedStats.WriteLine(newPokemanData[line].Hp.ToString() + " " +
                                            newPokemanData[line].Atk.ToString() + " " +
                                            newPokemanData[line].Def.ToString() + " " +
                                            newPokemanData[line].SpAtk.ToString() + " " +
                                            newPokemanData[line].SpDef.ToString() + " " +
                                            newPokemanData[line].Spe.ToString() + " "                                         
                        );
                
                }
            }
            //
        }
