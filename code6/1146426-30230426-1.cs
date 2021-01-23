    // Copied your array definiton:
    var page = new string[44];
    string notes = "blah \n blah \n";
    string[] notesSplit = notes.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
    
    // The suggested solution:
    if (notesSplit.Length < 10) 
    {    
        Array.Resize(ref notesSplit, 10);
    }
    Array.Copy(notesSplit, 0, page, 20, 10);
