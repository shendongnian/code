    // LINQ
    using System.Linq;
    // Creates a string[][] array with the list of keys in the first array position
    // and the values in the second
    var lines = File.ReadAllLines(@"path/to/file.txt")
                    .Select(s => s.Split('\t'))
                    .ToArray();
    // Your dictionary
    Dictionary<string, string> stations = new Dictionary<string, string>();
    // Loop through the array and add the key/value pairs to the dictionary
    for (int i = 0; i < lines.Length; i++)
    {
        // For example lines[i][0] = ABW, lines[i][1] = Abbey Wood
        stations[lines[i][0]] = lines[i][1];
    }
    // Prove it works
    foreach (KeyValuePair<string, string> entry in stations)
    {
        MessageBox.Show(entry.Key + " - " + entry.Value);
    }
