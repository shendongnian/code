    for (int i = 0; i < lineCounter.Count(); ++i) {
		int dotIndex = lineCounter[i].IndexOf('.');
		if (dotIndex < 1) { //must be at least in the position of 2 or above
            //Print here
			continue;		
        }
		int lineIndex = 0;
		if (int.TryParse(lineCounter[i].Substring(0, dotIndex), out lineIndex)) { //if can be parsed
			lineIndex--; //decrement lineIndex
			lineCounter[i] = lineIndex.ToString() + lineCounter[i].Remove(0, dotIndex);
		}
        //Print here also
	}
