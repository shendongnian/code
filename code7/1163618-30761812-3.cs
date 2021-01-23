    string value = textBox3.Text;
    Match match = Regex.Match(value, @".*[0-9].*");
    Console.WriteLine(value);
    int TotalRows = xlsDs.Rows.Count;
    for(int i=0;i<TotalRows;i++)
     {
       DataRow row = xlsDs.Rows[i];
       String row_Val=row["Cell_Name"].ToString();//Put Cell you want to match IE ID
       Match myMatch = Regex.Match(row_Val, textBox3.Text);
       if (match.Success && myMatch.Success)
       {    
             Console.WriteLine(textBox3);
             Console.Write(row.ItemArray.ToString());
             //Console.WriteLine(row["Cell_Name"]);//if you want to print a specific cell
             Console.WriteLine("This was found at row "+i);
        }
     }
