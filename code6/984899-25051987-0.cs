    enter code herepublic class Domain 
	{ 
		public int Id {get; set; } 
		public string Dom {get; set;}
	}
	public class Report
	{
		public int Id {get; set;} 
		public DateTime Created {get; set;}
        public int DomainId { get; set; }
	}
    List<Domain> objDomain = new List<Domain>();
            List<Report> objReport = new List<Report>();
            Domain objD1 = new Domain();
            Report objR1 = new Report();
            objD1.Id = 1;
            objD1.Dom = "google.com";
            objR1.Id = 1;
            objR1.DomainId = 1;
            objDomain.Add(objD1);
            objReport.Add(objR1);
             Domain objD2 = new Domain();
            Report objR2 = new Report();
            objD2.Id = 2;
            objD2.Dom = "yahoo.com";
            objR2.Id = 2;
            objR2.DomainId = 1;
            objDomain.Add(objD2);
            objReport.Add(objR2);
     int count = objDomain.Count(Domaindata => objReport.Any(ReportData => ReportData.DomainId != Domaindata.Id)); 
