    public class Member
    {
    	[Key][AutoIncromentCode]
    	public int Id {get; set;} 
    	public string MemberNo {get; set;}
    	public string FirstName { get; set;}
    	public int MemberStatusId { get; set;}
    	
    	public int ImportHistortId { get; set;}
    	
    	[NotMapped]
    	public MemberStatus
    	{
    		return (Status)MemberStatusId
    	}
    }
    
    public enum Status
    {
    	NoChange = 0,
    	New = 1,
    	Current = 2,
    	Resigned = 3,
    	Suspended = 4,
    	Reinstated = 5,
    }
    
    public class MemberStatusDto
    {
    	public Member NewMember {get; set;}
    	public Member OldMember {get; set;}
    }
    
    public void GetSomeStuff(int importHistortId )
    {
    	List<MemberStatusDto> result  = ( from N_Memeber in Content.Member
    									  join O_Member in Content.Member on 
    									  new { N_Memeber.MemberNo, O_Member.ImportHistortId } equals new {MemberNo = O_Member.MemberNo, ImportHistortId = importHistortId }
    									  into T_Members
    									  from A_Members in T_Members.DefaultIfEmpty()
    									  where N_Memeber.ImportHistoryID = importHistortId
    									 select new MemberStatusDto()
    									 {
    										NewMember = A_Members.N_Memeber,
    										OldMember = A_Members.O_Member
    									 }).Tolist();				
    									 
    	foreach(var item in result)
    	{
    		var NewState = item.NewMember.MemberStatus;
    		var oldState = (item.OldMember == null) ? "nothing" : item.OldMember.MemberStatus
    		
    	}
    }
