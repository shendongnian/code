	string [] sAAA = { 
		"asdf1234asdf",
		"asdf .1234asdf",
		"asdf. .1234asdf",
		"asdf 12.34asdf",
		"asdf123.4 asdf",
		"asdf.1234asdf",
		};
	Regex RxAAA = new Regex(@"((?((?!\.\d))\D)*)(\d*\.\d+|\d+)((?((?<=\d)).*))");
	for (int i = 0; i < sAAA.Length; i++)
	{
		Match _mAAA = RxAAA.Match( sAAA[i] );
		if (_mAAA.Success)
		{
			Console.WriteLine("1. = \"{0}\", \t2. = \"{1}\", \t3. = \"{2}\"",
				_mAAA.Groups[1].Value, _mAAA.Groups[2].Value, _mAAA.Groups[3].Value );
		}
	}
