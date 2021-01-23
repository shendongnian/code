    int maxCol = 0;
    int columns = sheet.UsedRange.Columns.Count;
    Range fastRange = sheet.get_Range("R12C1", "R12C" + columns); //Gets row 12 to used Range
    foreach(Range r in fastRange){
        if(String.IsNullOrEmpty(r.Text) && r.Column > maxCol) maxCol = r.Column;
    }
    Console.WriteLine("Max column for row 12 is: " + maxCol);
