    List<Member> members = new List<Member>();
    
    public static List<Member> Search(Func<Member, bool> criteria)
    {
        IEnumerable<Member> result = members.Where(criteria);
    
        // Do other stuff, manipulate results...
    
        return result;
    }
