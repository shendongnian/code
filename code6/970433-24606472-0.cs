    string s = (string)dtR[dtC]; // read the contents of a cell
    s = s.Replace("foo", "newfoo"); // perform some string replacements...
    s = s.Replace("bar", "newbar");
    s = s.Replace("blap", "newblap");
    dtR[dtC] = s; // store it back into the cell
