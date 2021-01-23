    public static List<Member> Search(Func<Member, bool> criteria)
    {
        List<Member> members = new List<Member>();
    
        IEnumerable<Member> result = members.Where(criteria);
    
        // Do other stuff, manipulate results...
    
        return result;
    }
