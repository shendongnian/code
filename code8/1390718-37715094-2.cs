    var _eValA = new string[0];
    var _eValB = new string[0];
    foreach (var file in files)
    {
        if (i == 1)
        {
             _eValA = File.ReadLines(file.Name);
            ++i;
        }
        else 
        {
            _eValB = File.ReadLines(file.Name);
            i = 1;
        }
    }
