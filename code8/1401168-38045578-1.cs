You are very close. Use Matches instead of Match. 
Also, correct your Regex as \D captures non-digit characters.
	public class SceneComparer : IComparer
    {
        private readonly Regex sceneRegEx = new Regex(@"(\d+)(\w+)?", RegexOptions.Compiled);
        public int Compare(object x, object y)
        {
            Scene sceneX = x as Scene;
            Scene sceneY = y as Scene;
            var firstSceneMatches = this.sceneRegEx.Matches(sceneX.SceneNumber);
            var secondSceneMatches = this.sceneRegEx.Matches(sceneY.SceneNumber);
            var matchesCount = Math.Min(firstSceneMatches.Count, secondSceneMatches.Count);
            for (var i = 0; i < matchesCount; i++)
            {
                var firstSceneMatch = firstSceneMatches[i];
                var secondSceneMatch = secondSceneMatches[i];
                var firstSceneNumeric = Convert.ToInt32(firstSceneMatch.Groups[1].Value);
                var secondSceneNumeric = Convert.ToInt32(secondSceneMatch.Groups[1].Value);
                if (firstSceneNumeric != secondSceneNumeric)
                {
                    return firstSceneNumeric - secondSceneNumeric;
                }
                var firstSceneAlpha = firstSceneMatch.Groups[2].Value;
                var secondSceneAlpha = secondSceneMatch.Groups[2].Value;
                if (firstSceneAlpha != secondSceneAlpha)
                {
                    return string.CompareOrdinal(firstSceneAlpha, secondSceneAlpha);
                }
            }
            return firstSceneMatches.Count - secondSceneMatches.Count;
        }
    }
