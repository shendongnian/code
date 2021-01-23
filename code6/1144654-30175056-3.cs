    public bool MemberExists(Member member) 
    {
       var memberExists = Sprinters.FirstOrDefault(m => m.RacerId == member.RacerId);
    
       return memberExists != null;
    }
