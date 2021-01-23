    string f1_txt = @"abc . DEF . ghi . JKL some, junk, some, junk, mno . PQR some junk stu . VWX";
    Regex Rx = new Regex(@"(?<!\S)(\w+)\s+\.(?=\s+(\w+)(?!\S))");
    
    Match _matchData = Rx.Match( f1_txt );
    while (_matchData.Success)
    {
    	if ( char.IsUpper(_matchData.Groups[ 2 ].Value[ 0 ] ) )
    		Console.WriteLine("Add {0} to ListBox1", _matchData.Groups[ 1 ].Value);
    	else
    		Console.WriteLine("Add {0} to ListBox2", _matchData.Groups[ 1 ].Value);
    	_matchData = _matchData.NextMatch();
    }
    return;
    
