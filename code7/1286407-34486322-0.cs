    Dictionary<int, int[]> matrix = new Dictionary<int, int[]>();
    // You could initialize this statically, or better yet, use Lazy<>
    static CompatibilityComparer()
    {
       matrix[1] = new[] { 2, 4 };
       ...
    } 
    public bool IsCompatible(Person a, Person b)
    {
       return matrix[a.Id].Contains(b.Id);
    }
