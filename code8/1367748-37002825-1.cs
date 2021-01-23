     public string[] Parser(string caminho)
            {
                List<string> Commands2 = new List<string>();
                string text = File.ReadAllText(caminho);
                var Linha = Regex.Replace(text, @"\/\**?\*\/", " ");
                var Commands = Linha.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries)
                   .Where(line => !string.IsNullOrWhiteSpace(line))
                   .Where(line => !Regex.IsMatch(line, @"^[\s\-]+$")) 
                   .ToArray();
    
    
                Commands2 = Commands.ToList();
              
               
              for(int idx = 0; idx < Commands2.Count; idx ++)
                {
                  
                    if (Commands2[idx].TrimStart().StartsWith("-"))
                    {
                        string linha = Commands2[idx];
                        string linha2 = linha.Remove(linha.IndexOf('-'), linha.LastIndexOf('-') - 1);
                        Commands2[idx] = linha2;
                    }
    
    
    
                }
              //test the output to a .txt file
                StreamWriter Comandos = new StreamWriter(Directory.GetParent(caminho).ToString() + "Out.txt", false);
                foreach (string linha in Commands2)
                {
                    Comandos.Write(linha);
                }
                Comandos.Close();
                return Commands2.ToArray();
            }
