    string x = ...
    string y = ...
    char[] c = new char[x.Length];
	for (int i = 0; i < x.Length; i++)
	{
	    c[i] = (char)(x[i] | y[i]);
	}
    string result = new string(c);
