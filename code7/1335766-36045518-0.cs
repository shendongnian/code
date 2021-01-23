	char []split = new char[]{' '};
	
    //replaces all " " with ";", contiguous "    " will be replaced with a single ";"
    var c2 = String.Join(";", content1.Split(split, StringSplitOptions.RemoveEmptyEntries)); 
	
    //replaces all newlines with a semicolon followed by a newline, thus appends a semicolon to the end of line. 
    var c3 = c2.Replace(System.Environment.NewLine, ";"+System.Environment.NewLine);
    //If the file did not end with an NewLine, append a semicolon to the last line
    if (!c3.EndsWith(System.Environment.NewLine)) c3+=";";
    File.WriteAllText(path, c3);
