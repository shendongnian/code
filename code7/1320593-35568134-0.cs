    string[] linesA = new string[5] { "41 Boundary Rd", "93 Boswell Terrace", "4/100 Lockrose St", "32 Williams Ave", "27 scribbly gum st sunnybank hills" };
    Regex r = new Regex(@"^[^ ]* [^ ]* [^ ]*");
    for (int i = 0; i < linesA.Length;i++ )
    {
        Console.WriteLine(r.Replace(linesA[i], ""));
    }
