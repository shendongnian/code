    string value = textBox3.Text;
    
    Console.WriteLine(value);
    int TotalRows = xlsDs.Rows.Count;
    for(int i=0;i<TotalRows;i++)
     {
       Match match = Regex.Match(value, @".*[0-9].*");
       Match myMatch = Regex.Match(value, textBox3.Text);
       if (match.Success && myMatch.Success)
       {
             DataRow row = xlsDs.Rows[i];
             Console.WriteLine(textBox3);
             Console.Write(row.ItemArray.ToString());
             //Console.WriteLine(row["Cell_Name"]);//if you want to print a specific cell
             Console.WriteLine("This was found")
        }
     }
