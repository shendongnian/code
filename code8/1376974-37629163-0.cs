	public static Type FetchGenericType(string typestring)
	{
		Match m;
		if ((m = Regex.Match(typestring, )).Success)
		{
			string cls = m.Groups["class"].ToString();
			string par = m.Groups["params"].Success ? m.Groups["params"].ToString() : "";
			List<string> paramtypes = new List<string>();
			int s = 0, e = 0;
			for (int i = 0, c = 0, l = par.Length; i < l; i++)
				switch (par[i])
				{
					case ',':
						if (c > 0)
							goto default;
						paramtypes.Add(par.Substring(s, e));
						s = i + 1;
						e = 0;
						break;
					case '<': ++c;
						goto default;
					case '>': --c;
						goto default;
					default: ++e;
						break;
				} // I know, that this is bad as hell, but what should I do instead?
			paramtypes.Add(par.Substring(s, e));
			IEnumerable<Type> @params = from type in paramtypes
										where !string.IsNullOrWhiteSpace(type)
										select FetchGenericType(type);
			string paramstring = string.Join(", ", from type in @params select "[" + type.FullName + ", " + type.Assembly.GetName().Name + "]");
			string result = @params.Count() == 0 ? cls : string.Format("{0}`{1}[{2}]", cls, @paramsCount(), paramstr);
			// The string has now the format '...List`1[[System.String, mscorlib]]'
			// or: 'System.Tuple[[System.Int32, mscorlib], [System.Object, mscorlib]]' ...
			return FetchType(result);
		}
		else
			return FetchType(typestring);
	}
	
