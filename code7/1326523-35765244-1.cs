        if (input2.Contains(string.Empty))
        {
            string cleanedString = System.Text.RegularExpressions.Regex.Replace(input2, @"\s+", "_");
            Console.WriteLine(cleanedString);
        }
