	using System;
	using System.Collections.Generic;
	using System.Linq;
	namespace StackOverflowAnswer
	{
		class Program
		{
			static string[] songs = new string[] { "song1", "song2", "song3" };
			static string[] days = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
			static void Main(string[] args)
			{
				var rnd = new Random();
				var allCombinationsInRandomOrder = GetCombinations(songs, songs.Length)
					.Select(combination => new { Combination = combination, Order = rnd.Next() })
					.OrderBy(entry => entry.Order)
					.Select(entry => entry.Combination);
				var dayIndex = 0;
				foreach (var combination in allCombinationsInRandomOrder)
				{
					var day = days[dayIndex];
					Console.WriteLine(day);
					Console.WriteLine(string.Join(", ", combination));
					dayIndex++;
					if (dayIndex >= days.Length)
						break;
				}
				Console.ReadLine();
			}
			private static IEnumerable<IEnumerable<string>> GetCombinations(IEnumerable<string> songs, int numberOfSongsInGeneratedLists)
			{
				if (songs == null)
					throw new ArgumentNullException(nameof(songs));
				if (numberOfSongsInGeneratedLists <= 0)
					throw new ArgumentOutOfRangeException(nameof(numberOfSongsInGeneratedLists));
				if (numberOfSongsInGeneratedLists > songs.Count())
					throw new ArgumentOutOfRangeException("can't ask for more songs in the returned combinations that are provided", nameof(numberOfSongsInGeneratedLists));
				if (numberOfSongsInGeneratedLists == 1)
				{
					foreach (var song in songs)
						yield return new[] { song };
					yield break;
				}
				foreach (var combinationWithOneSongTooFew in GetCombinations(songs, numberOfSongsInGeneratedLists - 1))
				{
					foreach (var song in songs.Where(song => !combinationWithOneSongTooFew.Contains(song)))
						yield return combinationWithOneSongTooFew.Concat(new[] { song });
				}
			}
		}
	}
