    var rows = File.ReadAllLines("C:\YourDirectory\data.csv"); //get all rows/lines
    foreach(var row in rows)
    {
        //string[] fields = RemoveEmptyEntriesAtEnd(row.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries));
        string[] fields = RemoveEmptyEntriesAtEnd(row.Split(','));
        tbmodel.Text = fields[0]; //and other models.....
        tbmodelN.Text = fields.Length > N ? fields[N] : string.Empty; //when using N-th index of field
    }
    //The helper method
    public static string[] RemoveEmptyEntriesAtEnd(string[] strArray)
    {
        var arrRev = strArray.Reverse();
        var emptyEntriesAtEnd = 0;
        foreach (var item in arrRev)
        {
            if (string.IsNullOrWhiteSpace(item))
                emptyEntriesAtEnd++;
            else
                break;
        }
        return arrRev.Skip(emptyEntriesAtEnd).Reverse().ToArray();
    }
