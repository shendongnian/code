    // There are better ways to create a file, but I decided to keep it in the original.
    const string filePath = @"C:\Users\ariak_000\Desktop\Řadící algoritmy\database\alpha.txt";
    var rnd = new Random();
    if (!File.Exists(filePath))
    {
        var array = new string[50].Select(x => String.Join(";", new[]
        {
            @"C:\user\directory", 
            "file" + rnd.Next(100, 999), 
            rnd.Next(0, 999999).ToString(CultureInfo.InvariantCulture), 
            "txt", 
            rnd.Next(0, 1).ToString(CultureInfo.InvariantCulture)
        })).ToArray();
        File.WriteAllLines(filePath, array);
    }
    // It will read the file and fill a variable with the data
    // Convert the value to int is necessary in the order process
    // Otherside, it will consider 9 higher than 10.
    var data = File.ReadAllLines(filePath)
        .Select(value => value.Split(';'))
        .Select(x => new
        {
            Folder = x[0],
            FileName = x[1],
            Size = Convert.ToInt32(x[2]),
            Extension = x[3],
            IsActive = x[4]
        })
        .ToList<dynamic>();
    // You can change it using the bubble sort as you wish
    // I preffer the linq way.
    var orderedData = data.OrderByDescending(x => x.Size);
    // Writes the header in console (du~)
    Console.WriteLine("Folder" + "\t\t\t"
                    + "FileName" + "\t"
                    + "Size" + "\t"
                    + "Extension" + "\t"
                    + "IsActive");
    foreach (var result in orderedData)
    {
        // If you want to write the result in a file, you do it here.
        Console.WriteLine(result.Folder + "\t"
                        + result.FileName + "\t\t"
                        + result.Size + "\t"
                        + result.Extension + "\t\t"
                        + result.IsActive);
    }
    Console.ReadKey();
