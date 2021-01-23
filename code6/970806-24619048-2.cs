    public void RemoveTicketPeople([FromUri]int ticketId, [FromBody]int[] personIds)
            {
                    db.TicketPeople.Where(t => t.TicketId == ticketId)
                    .Where(t => personIds.Contains( t.PersonId.Value)).ToList()
                    .ForEach(t => db.TicketPeople.Remove(t));
                    db.SaveChanges();
            }
