    public static List<string> FindStrings(string s, int n) {
        if (n == 0) {
			if (string.IsNullOrWhiteSpace(s)) {
				return new List<string>{ };
			}
			return null; // null means invalid
        }
    
        for (var i=s.Length-1; i>=0; i--){
            var startOfString = s.Substring(0, i);
            var endOfString = s.Substring(i);
            var list = FindStrings(startOfString, n-1);
			
			// invalid... gotta continue to next try
			if (list == null) continue;
			
            // make sure there are no matches so far
            if (list.Contains(endOfString)) continue;
			// bingo!
            if (list.Count == n-1) {
                list.Add(endOfString);
				return list;
            }
        }
    
        return null; // null means invalid
    }
