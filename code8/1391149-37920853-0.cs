    var ticketsCollection = _mongoConnect.Database.GetCollection<BsonDocument>("Tickets");
    
                var dbResult = from ticket in ticketsCollection.AsQueryable()
                    select new
                    {
                        TicketProjectID = ticket["TicketProjectID"],
                        TicketID = ticket["TicketID"],
                        ConcatValue = ticket["Status"] + (string) ticket["Name"]
                    };
                var matches = from dbr in dbResult
                    where dbr.ConcatValue.Contains(searchKey)
                    where dbr.ConcatValue.StartsWith(searchKey)
                    select dbr;
