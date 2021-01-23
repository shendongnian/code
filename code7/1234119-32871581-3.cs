    string[] vowels = new string[] { "A", "a", "E", "e", "I", "i", "O", "o", "U", "u" };
    string[] names = new string[5];
    names[0] = "john";
    names[1] = "samuel";
    names[2] = "kevin";
    names[3] = "steve";
    names[4] = "martyn";
    for (int i = 0; i < names.Length; i++)
    {
        for (int j = 0; j < vowels.Length; j++)
        {
            names[i] = names[i].Replace(vowels[j], "");
        }
        Console.WriteLine("The output is:" + names[i]);
    }
