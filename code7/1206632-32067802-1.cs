	public class SceneNumberComparer : IComparer<string>
	{
		// Assumes that a scene is either numeric, or numeric + alpha.
		private readonly Regex sceneRegEx = new Regex(@"(\d*)(\w*)", RegexOptions.Compiled);
		public int Compare(string x, string y)
		{
			var firstSceneMatch = this.sceneRegEx.Match(x);
			var firstSceneNumeric = Convert.ToInt32(firstSceneMatch.Groups[1].Value);
			var firstSceneAlpha = firstSceneMatch.Groups[2].Value;
			var secondSceneMatch = this.sceneRegEx.Match(y);
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
