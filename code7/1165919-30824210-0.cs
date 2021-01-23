    public List<char> vowels = "AEIOUaeiou".ToList();
    public bool isBothVowelsAndEqual(char first, char second)
        {
           return (first == second && vowels.Contains(first));
        }
    
    const string s = "I am keeeping a foobar";
    string output=String.Empty;
    for (int i = 0; i < s.Length-1; i++)
    {
        if (isBothVowelsAndEqual(s[i], s[i + 1]))
        {                        
           output = output + s[i] + s[i+1];
           i++;
        }
        else
        {
           if (!vowels.Contains(s[i])) {
           output += s[i];
        }
      }                
    }
    Console.WriteLine(output.Trim());
