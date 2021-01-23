    public class Database
    {
        public static IEnumerable<First> GetChildren()
        {
            List<First> firsts = new List<First>();
            firsts.Add(new First("John"));
            firsts.Add(new First("Roxanne"));
            return firsts;
        }
    }
