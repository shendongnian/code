    string str = @"\\adbc/\\abrc/";
    //Regex RxAbc = new Regex(@"(?:(\\\w+/)|.)+");
    Regex RxAbc = new Regex(@"(?:.*?(\\\w+/))+");
    Match _mAbc = RxAbc.Match(str);
    if (_mAbc.Success)
    {
    	CaptureCollection cc = _mAbc.Groups[1].Captures;
    	for (int i = 0; i < cc.Count; i++)
    	{
    		Console.WriteLine("{0}", cc[i].Value);
    	}
    }
