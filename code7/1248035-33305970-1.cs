    var rows = File.ReadAllLines("C:\YourDirectory\data.csv"); //get all rows/lines
    foreach(var row in rows)
    {
        string[] fields = RemoveEmptyEntriesAtEnd(row.Split(new char[] { ',' }));
        tbmodel.Text = fields[0]; //and other models.....
    }
    The helper method
    public static string[] RemoveEmptyEntriesAtEnd(string[] strArray)
    {
        var lastIndex = -1;
        foreach (var item in strArray)
        {
            if (!string.IsNullOrWhiteSpace(item))
                lastIndex++;
            else
                break;
        }
        return strArray.Take(lastIndex).ToArray();
    }
