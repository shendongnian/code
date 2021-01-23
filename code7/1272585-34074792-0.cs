    {
    	"results":[
    	  {"Seat":"5","createdAt":"2015-11-29T18:50:15.320Z","objectId":"BsDSolYPsT","updatedAt":"2015-11-29T19:40:55.020Z"},
    	  {"Seat":"6","createdAt":"2015-12-02T22:31:36.892Z","objectId":"kQJ0R5TUvw","updatedAt":"2015-12-02T22:31:36.892Z"},
    	  {"Seat":"7","createdAt":"2015-12-02T22:31:40.261Z","objectId":"sVtdj3aipb","updatedAt":"2015-12-02T22:31:40.261Z"},
    	  {"Seat":"8","createdAt":"2015-12-02T22:31:43.082Z","objectId":"7oH2ySrDFH","updatedAt":"2015-12-02T22:31:43.082Z"}
    	  ]
    }
    public class Result
    {
        public string Seat { get; set; }
        public string createdAt { get; set; }
        public string objectId { get; set; }
        public string updatedAt { get; set; }
    }
    
    public class RootObject
    {
        public List<Result> results { get; set; }
    }
