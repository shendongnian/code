    public void SwitchLetters(string newStr)
    {
        StringBuilder myString = new StringBuilder();
        for (int i = 0; i < newStr.Length; i++)
        {
            if (char.IsUpper(newStr, i))
                myString.Append(char.ToLower(newStr[i]));
            else if (char.IsLower(newStr, i))
                myString.Append(char.ToUpper(newStr[i]));
            else
                myString.Append(newStr[i]);
            Console.WriteLine(myString.ToString());
            //Console.ReadLine(); This line needs to be removed
            Console.WriteLine(newStr.ToUpper());
        }
    }
