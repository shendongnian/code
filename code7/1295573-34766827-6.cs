    var lines = File.ReadAllLines(fileName).ToList();
    ..
    string[] sep = { ";" };
    var p0 = ("Nr" + sep[0] + lines[0]).Split(sep, StringSplitOptions.None );
    DT.Columns.Clear();
    for (int i = 0; i < p0.Length; i++) DT.Columns.Add(p0[i], typeof(string));
