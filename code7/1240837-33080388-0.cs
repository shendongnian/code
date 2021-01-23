    public static class HeartrateGenerator
    {
        static Random random = new Random();
        public static IEnumerable<int> GenerateHeartrate(
            int totalSequenceLength,
            int dropsBelow60After, 
            int bouncesBackAfter = -1)
        {
            // NOTE: check input data
            int i = 0;
            // return values > 60
            while (i < dropsBelow60After)
            {
                i++;
                yield return 60 + random.Next() % 60;
            }
            if (bouncesBackAfter > 0)
                // return values < 60
                while (i < bouncesBackAfter)
                {
                    i++;
                    yield return random.Next() % 60; 
                }
            // return normal values again
            while (i < totalSequenceLength)
            {
                i++;
                yield return 60 + random.Next() % 60;
            }
        }
    }
