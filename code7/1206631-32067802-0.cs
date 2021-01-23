	namespace SceneSorter
	{
		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Text.RegularExpressions;
		class Program
		{
			static void Main(string[] args)
			{
				var sceneList = new List<Scene>
									{
										new Scene { SceneNumber = "1" },
										new Scene { SceneNumber = "10" },
										new Scene { SceneNumber = "15A" },
										new Scene { SceneNumber = "2" },
										new Scene { SceneNumber = "30B" },
										new Scene { SceneNumber = "4B" },
										new Scene { SceneNumber = "4A" }
									};
				foreach (var scene in sceneList.OrderBy(x => x, new SceneComparer()))
				{
					Console.WriteLine(scene.SceneNumber);
				}
			}
		}
		public class Scene
		{
			// TODO: Consider splitting SceneNumber into a e.g. a numeric "main scene" and an alpha "sub scene".
			public string SceneNumber { get; set; }
		}
		public class SceneComparer : IComparer<Scene>
		{
			// Assumes that a scene is either numeric, or numeric + alpha.
			private readonly Regex sceneRegEx = new Regex(@"(\d*)(\w*)", RegexOptions.Compiled);
			public int Compare(Scene x, Scene y)
			{
				var firstSceneMatch = this.sceneRegEx.Match(x.SceneNumber);
				var firstSceneNumeric = Convert.ToInt32(firstSceneMatch.Groups[1].Value);
				var firstSceneAlpha = firstSceneMatch.Groups[2].Value;
				
				var secondSceneMatch = this.sceneRegEx.Match(y.SceneNumber);
				var secondSceneNumeric = Convert.ToInt32(secondSceneMatch.Groups[1].Value);
				var secondSceneAlpha = secondSceneMatch.Groups[2].Value;
				if (firstSceneNumeric < secondSceneNumeric)
				{
					return -1;
				}
				if (firstSceneNumeric > secondSceneNumeric)
				{
					return 1;
				}
				return string.CompareOrdinal(firstSceneAlpha, secondSceneAlpha);
			}
		}
	}
----------
	1
	2
	4A
	4B
	10
	15A
	30B
	Press any key to continue . . .
