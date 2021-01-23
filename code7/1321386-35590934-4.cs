            foreach (Match m in Regex.Matches(s, "#START#(.*?)#END#", RegexOptions.Singleline | RegexOptions.Compiled))
            {
                foreach (var line in m.Groups[1].Value.Split('\n')) Console.WriteLine(line);
                Console.WriteLine();
            }
            Console.ReadLine();
