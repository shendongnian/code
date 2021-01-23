    class Program
    {
        static void Main(string[] args)
        {
            var enemyDatas = new List<EnemyData>
            {
                new EnemyData
                {
                    EnemyName = "Name1",
                    EnemyHealth = 50,
                    EnemyId = 1,
                    EnemyType = EnemyType.Bad
                },
                new EnemyData
                {
                    EnemyName = "Name2",
                    EnemyHealth = 100,
                    EnemyId = 2,
                    EnemyType = EnemyType.VeryBad
                }
            };
        }
    }
    public class EnemyData
    {
        public int EnemyId { get; set; }
        public int EnemyHealth { get; set; }
        public EnemyType EnemyType { get; set; }
        public string EnemyName { get; set; }
    }
    public enum EnemyType
    {
        Bad,
        VeryBad
    }
