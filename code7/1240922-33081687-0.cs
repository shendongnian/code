			List<Version> versions = new List<Version>();
			List<string> versionStrings;
			// get somehow, the list of version strings in "Version format" - nothing else except x.y.z.k
			versionStrings = new List<string>(
				new string[]{ "5.8.0.1",
					"5.8.0.10",
					"5.8.0.11",
					"5.8.0.2" }
				);
			// pupulate list of Version from list of string
			versionStrings.ForEach(str => versions.Add(new Version(str)));
			//list is not orderded
			versions.ForEach(ver => System.Diagnostics.Debug.WriteLine(ver));
			// sort the list using the default Version comparison
			versions.Sort();
			// list is ordered
			versions.ForEach(ver => System.Diagnostics.Debug.WriteLine(ver));
