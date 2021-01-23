	public enum AgeGroup
	{
		UnderEighteen,
		NineteenToThirty,
		ThirtyoneToFortyfive,
		FortysixToSixtyfour,
		SixtyfiveAndUp,
	}
	
	class Program
	{
		static void Main(string[] args)
		{
			int[] dists = new int[22];
			Dictionary<AgeGroup, int> ageGroups = new Dictionary<AgeGroup, int>()
			{
				{ AgeGroup.UnderEighteen, 0 },
				{ AgeGroup.NineteenToThirty, 0 },
				{ AgeGroup.ThirtyoneToFortyfive, 0 },
				{ AgeGroup.FortysixToSixtyfour, 0 },
				{ AgeGroup.SixtyfiveAndUp, 0 },
			};
			
			textfilereader(dists, ageGroups);
		}
	
		static void textfilereader(int[] dists, Dictionary<AgeGroup, int> ageGroups)
		{
			foreach (var inputrecord in File.ReadAllLines("project2.txt"))
			{
				string[] fields = inputrecord.Split(',');
				int age;
				if (int.TryParse(fields[0], out age))
				{
					agegroupcounter(age, ageGroups);
				}
				int livingIn;
				if (int.TryParse(fields[3], out livingIn))
				{
					districtCounter(livingIn, dists);
				}
			}
	
			Finalcount(dists, ageGroups);
		}
	
		static void Finalcount(int[] dists, Dictionary<AgeGroup, int> ageGroups)
		{
			Console.WriteLine("The age group tallies are");
			Console.WriteLine(" Eighteen and under = {0}", ageGroups[AgeGroup.UnderEighteen]);
			Console.WriteLine(" Nineteen to thirty = {0}", ageGroups[AgeGroup.NineteenToThirty]);
			Console.WriteLine(" Thirtyone to fortyfive = {0}", ageGroups[AgeGroup.ThirtyoneToFortyfive]);
			Console.WriteLine(" fortysix to sixtyfour = {0}", ageGroups[AgeGroup.FortysixToSixtyfour]);
			Console.WriteLine("Sixtyfive and older = {0}", ageGroups[AgeGroup.SixtyfiveAndUp]);
			Console.WriteLine("");
	
			Console.WriteLine("The total of persons living in each district");
			for (var i = 0; i < dists.Length; i++)
			{
				Console.WriteLine("Distict {0} = {1}", i + 1, dists[i]);
			}
		}
	
	
		static void districtCounter(int livingIn, int[] dists)
		{
			if (livingIn <= 0 && livingIn >= 23)
			{
				cancel();
			}
			else
			{
				dists[livingIn - 1]++;
			}
		}
		
		static void agegroupcounter(int age, Dictionary<AgeGroup, int> ageGroups)
		{
			if (age < 0)
			{
				cancel();
			}
			else if (age <= 18)
			{
				ageGroups[AgeGroup.UnderEighteen]++;
			}
			else if (age >= 19 || age <= 30)
			{
				ageGroups[AgeGroup.NineteenToThirty]++;
			}
			else if (age >= 31 || age <= 45)
			{
				ageGroups[AgeGroup.ThirtyoneToFortyfive]++;
			}
			else if (age >= 46 || age <= 64)
			{
				ageGroups[AgeGroup.FortysixToSixtyfour]++;
			}
			else
			{
				ageGroups[AgeGroup.SixtyfiveAndUp]++;
			}
		}
	
		static void cancel()
		{
			Console.WriteLine("Invalid Data Was Entered please check your text file for any irregularities");
		}
	}
