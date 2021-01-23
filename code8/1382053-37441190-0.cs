        List<string> lines = new List<string>
    {
        "\"NAME\", \"AGE\", \"SEX\"",
        "\"FRED, JONES\", \"45\", \"MALE\"",
        "\"SALLY, SMITH\", \"60\", \"FEMALE\""
    };
        foreach (var line in lines.Skip(1))
        {
            var fields = line.Trim(new char[] { '"' }).Split(new string[] { "\", \"" }, StringSplitOptions.None);
            foreach (var field in fields)
                Console.WriteLine(field.Trim());
            Console.WriteLine();
        }
