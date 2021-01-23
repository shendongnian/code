	public delegate string RollDelegate();
	private void Test() {			
		List<string> rollMethodNames = new List<string>(){
			"Large Lookup",
			"Lookup Optimized Modded",
			"Fastest Optimized Modded",
			"Optimized Modded Const",
			"Optimized Modded",
			"Modded",
			"Simple",
			"Another simple with HashSet",
			"Another Simple",
			"Option (Compiled) Regex",
			"Regex",
			"EndsWith",
		};
		List<RollDelegate> rollMethods = new List<RollDelegate>{
			RollLargeLookup, 
			RollLookupOptimizedModded, 
			FastestOptimizedModded,
			RollOptimizedModdedConst,
			RollOptimizedModded,
			RollModded,
			RollSimple,
			RollSimpleHashSet,
			RollAnotherSimple,
			RollOptionRegex,
			RollRegex,
			RollEndsWith
		};
		int trial = 10000000;
		InitLargeLookup();
		for (int k = 0; k < rollMethodNames.Count; ++k) {
			rnd = new Random(10000);
			logBox.GetTimeLapse();
			for (int i = 0; i < trial; ++i)
				rollMethods[k]();
			logBox.WriteTimedLogLine(rollMethodNames[k] + ": " + logBox.GetTimeLapse());
		}
	}
