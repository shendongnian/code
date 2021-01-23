    var values = new List<double?>(); // nullable, to handle parse errors
    
    string path = @"D:\finatt.txt";
    using (var sr = new StreamReader(path))
    {
                    
        string line;
                    
        var lineCount = 0;
        while ((line = sr.ReadLine()) != null)
        {
            lineCount++;
            // line does now have this value
            // bb--------->0.918295818426175
            var split = line.Split('>');
            // in split[0] we now have bb------
            // in split[1] we now have 0.918295818426175
            // find where the - starts
            var startOfDash = split[0].IndexOf('-');
            // so we can get the column name 
            var col = split[0].Substring(0, startOfDash);
            // add that column,
            dt1.Columns.Add(col, typeof(double));
            // store split[1] in the values list to be processed later
            // parse to a double
            double value;
            if (Double.TryParse(split[1],
                NumberStyles.AllowDecimalPoint,
                new NumberFormatInfo { NumberDecimalSeparator = "." },
                out value))
            {
                values.Add(value);
            }
            else
            {
                // make sure the values array has the same
                // number of entries as we have columns
                values.Add(null);
                Trace.WriteLine(String.Format("Error on line {0}, for {1} parsing value {2}", lineCount, split[0], split[1]));
            }
        }
    }
    var row = dt1.NewRow();
    dt1.Rows.Add(row);
    // assign the values array to the row
    // Cast the double the an object in the process.
    row.ItemArray = values.Cast<object>().ToArray();
    
    // done all, shows data
    dataGridView1.DataSource = dt1;
