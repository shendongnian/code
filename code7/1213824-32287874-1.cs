    StringBuilder sb = new StringBuilder();
    foreach (DataRow row in student.Rows)
    {
        // Concatenate all 
        sb.Append("(" + string.Join(",", row.ItemArray) + ")");
        sb.AppendLine();  // Add a new line (or a sb.Append(",") for a comma)
    }
    Console.WriteLine(sb.ToString());
