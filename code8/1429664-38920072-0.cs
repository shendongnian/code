    public static IList<string> ReadFile(string fileName)
        {
            var target = File.ReadAllLines(fileName).ToList();
            // i = 1 (skip first line)
            for (int i = 1; i < target.Count; i++)
            {
               target[4] = target[4].Replace(' ', ','); //replace the space in position 4(field 5)
            }
            File.WriteAllLines(fileName, target);
            // Uncomment the RemoveAt(0) to remove first line
            // target.RemoveAt(0);
            return target;
        }
