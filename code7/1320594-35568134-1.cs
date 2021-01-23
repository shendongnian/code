    string[] linesA = new string[5] { "41 Boundary Rd", "93 Boswell Terrace", "4/100 Lockrose St", "32 Williams Ave", "27 scribbly gum st sunnybank hills" };
    Regex r = new Regex(@"^[^ ]* [^ ]* [^ ]* *");
    foreach (string s in linesA)
    {
        Console.WriteLine(r.Replace(s, ""));
    }
