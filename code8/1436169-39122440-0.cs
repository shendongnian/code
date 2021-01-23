            struct Thing
    		{
    			public string From { get; }
    			public string To { get; }
    			public DateTime FromDate { get; }
    			public DateTime ToDate { get; }
    
    			public Thing(string @from, string to, DateTime fromDate, DateTime toDate)
    			{
    				From = @from;
    				To = to;
    				FromDate = fromDate;
    				ToDate = toDate;
    			}
    
    			public override string ToString()
    			{
    				return $"{From}-{To} Dates: {FromDate.ToShortDateString()} - {ToDate.ToShortDateString()}";
    			}
    		}
    
    		[Test]
    		public void Grouping()
    		{
    			var items = new List<Thing>
    			{
    				new Thing("S1", "S2", new DateTime(2016, 1, 1), new DateTime(2016, 1, 1)),
    				new Thing("S2", "S3", new DateTime(2016, 2, 1), new DateTime(2016, 3, 14)),
    				new Thing("S1", "S2", new DateTime(2016, 1, 5), new DateTime(2016, 1, 20)),
    				new Thing("S2", "S3", new DateTime(2016, 1, 25), new DateTime(2016, 2, 25)),
    				new Thing("S1", "S2", new DateTime(2016, 1, 21), new DateTime(2016, 1, 25))
    			};
    
    			var results = items.GroupBy(i => new {i.From, i.To})
    												 .Select(grp => new
    												 {
    													 grp.Key.From,
    													 grp.Key.To,
    													 items = grp.ToList()
    												 })
    												 .Select(grpd => new Thing(
    													 grpd.From, 
    													 grpd.To, 
    													 grpd.items.Min(x => x.FromDate), 
    													 grpd.items.Max(x=> x.ToDate)));
    
    			Assert.That(results, Is.EquivalentTo(new List<Thing>
    			{
    				new Thing("S1", "S2", new DateTime(2016, 1, 1), new DateTime(2016, 1, 25)),
    				new Thing("S2", "S3", new DateTime(2016, 1, 25), new DateTime(2016, 3, 14))
    			}));
    		}
