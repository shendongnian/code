    public static class FrameExtensions
    {
        public static int SumFrameScores(this Frame[] frames)
        {
            //break out early if no frames have been recorded
            if (frames.Length == 0) return 0;
            int totalScore = 0;
            var objScore = new EngineService();
            for (int i = 0; i < frames.Length; i++)
            {
                bool wasSpare = objScore.IsSpare(frames[i - 1]);
                totalScore += objScore.CalculateScore(frames[i], wasSpare);
            }
            return totalScore;
        }
    }
