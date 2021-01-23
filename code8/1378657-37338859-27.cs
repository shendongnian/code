	public delegate string RollDelegate();
	private void Test() {
		Dictionary<string, RollDelegate> rollMethods = new Dictionary<string, RollDelegate>(){
			{"Regex", RollRegex},
			{"Option (Compiled) Regex", RollOptionRegex},
			{"EndsWith", RollEndsWith},
			{"Simple", RollSimple},
			{"Another Simple", RollAnotherSimple},
			{"Another simple with HashSet", RollSimpleHashSet},
			{"Modded", RollModded},
			{"Optimized Modded", RollOptimizedModded},
			{"Optimized Modded Const", RollOptimizedModdedConst},
			{"Fastest Optimized Modded", FastestOptimizedModded},
		};
		int trial = 10000000;
		foreach (var rollMethod in rollMethods) {
			rnd = new Random(10000);
			logBox.GetTimeLapse();
			for (int i = 0; i < trial; ++i)
				rollMethod.Value();
			logBox.WriteTimedLogLine(rollMethod.Key + ": " + logBox.GetTimeLapse());
		}
	}
