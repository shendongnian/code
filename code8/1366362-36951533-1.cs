    var result = context.Mappings.Join(context.Mappings,
                mappings => mappings.User2,
                mappings2 => mappings2.User1,
                (mappings, mappings2) => new { mappings2.User2}), new IntegerNotEqulity()).Distinct()
                .Join(context.Users,
                arg => arg.User2, 
                user => user .UserId,
                (__ , user) => user )
                .ToList();
    public class IntegerNotEqulity :IEqualityComparer<int> 
        {
            public bool Equals(int x, int y)
            {
                return x != y;
            }
            public int GetHashCode(int obj)
            {
                return base.GetHashCode();
            }
        }
