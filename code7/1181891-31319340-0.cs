    using (var sin = new SteamReader("yourfile.csv")
    using (var sout = new SteamWriter("outfile.csv")
    {
        var line = sin.ReadLine();    // note: should add error handling for empty files
        var cells = line.Split(",");  // note: you should probably check the length too!
        var key = cells[0];           // use this to match other rows
        var output = line;            // this is the output line we will build
        while ((line = sin.ReadLine()) != null) // if we have more lines
        {
            cells = line.Split(",");    // split so we can get the first column
            while(cells[0] == key)      // if the first column matches the current key
            {
                output += String.Join(",",cells.Skip(4));   // add this row to our output line
            }
            // once the key changes
            sout.WriteLine(output);      // write out the line we've built up
            output = line;               // update the new line to build
            key = cells[0];              // and update the key
        }
        // once all lines have been processed
        sout.WriteLine(output);    // We'll have just the last line to write out
    }
