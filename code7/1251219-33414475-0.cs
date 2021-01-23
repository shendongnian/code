    public static class EnemyFactory
    {
        public static EnemyFighter MakeBeaver()
        {
            var beaver = new EnemyFighter
            {
                Name = "Beaver",
                Level = 1
            };
            return beaver;
        }
    }
