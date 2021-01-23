    string[] row = new string[numColumns];
    List<string> lines;
    // Add code here to read and parse your file
    // Each file line is added to lines
      foreach (var line in lines)
      {
            // Split the line into fields, comma assumed here
            string[] fields= line.Split(new char[] { '\t' });
            // Add validation of file contents
        	row[0] = fields[0];
        	row[1] = fields[1];
            // etc.
        	dataGridView1.Rows.Add(row);
        }
