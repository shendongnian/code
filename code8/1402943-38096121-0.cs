    string input = c:\My\Path\To\File\fileName_YYYY-MM-DD_HH-MM-SS.ext;
    string filename = Path.GetFilenameWithoutExtension(input);
    
    string[] parts = filename.Split('_');
    if (parts.Length != 3) { /*Invalid*/ }
   
    if (Path.GetExtension(input) != "ext") { /*Invalid*/ }
    if (parts[0] != "filename") { /*Invalid*/ }
    DateTime dt;
    if (!DateTime.TryParseExact(parts[1] + "_" + parts[2], "yyyy-MM-dd_HH-mm-ss",
        CultureInfo.InvariantCulture, DateTimeStyles.None, out dt)) 
    { /*Invalid*/ }
    //IsValid
