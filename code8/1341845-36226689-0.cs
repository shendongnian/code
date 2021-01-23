    public class LinkedUser
    {
    	public int Id { get; set; }
    	public int? ParentId { get; set; }
    	public string CardNumber { get; set; }
    	public int RootUserId { get; set; }
    }
    var linkedUserList =  new List<LinkedUser>()
    {
    	new LinkedUser {Id = 1, CardNumber = "546251357655", ParentId = null, RootUserId = 1},
    	new LinkedUser {Id = 5869, CardNumber = "666547395503", ParentId = 1, RootUserId = 1},
    	new LinkedUser {Id = 214, CardNumber = "666558432178", ParentId = 5869, RootUserId = 1},
    	new LinkedUser {Id = 8957, CardNumber = "987265985430", ParentId = 214, RootUserId = 1},
    	new LinkedUser {Id = 3650, CardNumber = "987653215430", ParentId = 8957, RootUserId = 1}
    };
 
    List<LinkedUser> SortedList = linkedUserList.OrderBy(o => o.ParentId).ToList();
