		static bool SafeIntParse(string s)
		{
			int n;
			return Int32.TryParse(s, out n);
		}
        var v = q.Where(x => SafeIntParse(x));
