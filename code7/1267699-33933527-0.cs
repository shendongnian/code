    public ActionResult Index()
    {
         var model = new IndexViewModel();
         var clientInfo = (from c in db.Customers
                          join a in db.Addresses
                              on c.ClientId equals a.CustomerId 
                          where c.RowId == 19
                          select new ClientInfo
                          {
                              ClientId = c.ClientId,
                              ClientGroup = c.ClientGroup,
                              ClientCategory = c.ClientCategory,
                              ClientType = c.ClientType,
                              ContactName = c.ContactName,
							  OrgName = c.OrgName,
							  Branch = c.Branch,
							  AddressLine1 = a.AddressLine1,
                             AddressLine2 = a.AddressLine2,
                             State = a.State,
                             City = a.City,
                             CreatedDate = a.CreatedDate,
                             ModifiedDate = a.ModifiedDate
                           }).FirstOrDefault();
         model.Details = clientInfo;
         
		 var addresses = (from a in db.Addresses 
                          where a.CustomerId == clientInfo.ClientId
                          select new AddressLineItem
                          {
                             AddressLine1 = a.AddressLine1,
                             AddressLine2 = a.AddressLine2,
                             State = a.State,
                             City = a.City,
                             CreatedDate = a.CreatedDate,
                             ModifiedDate = a.ModifiedDate
                           }).ToList();
		 model.List = addresses;
         return View();
     }
     }
	 
	 public class ClientInfo{
        public int ClientId { get; set; }
        public string ClientGroup { get;set; }
        public string ClientCategory {get; set; }
		public string ClientType {get; set; }
		public string ContactName {get; set; }
		public string OrgName {get; set; }
		public string Branch {get; set; }
		public string AddressLine1 {get; set; }
		public string AddressLine2 {get; set; }
		public string State {get; set; }
		public string City {get; set; }
		public DateTime CreatedDate {get; set; }
		public DateTime ModifiedDate {get; set; }
    }
    public class AddressListItem{
        public string AddressLine1 {get; set; }
		public string AddressLine2 {get; set; }
		public string State {get; set; }
		public string City {get; set; }
		public DateTime CreatedDate {get; set; }
		public DateTime ModifiedDate {get; set; }
    }
