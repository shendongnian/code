    public void RemoveTicketPeople([FromUri]int ticketId, [FromBody]int[] personIds)
            {
                    db.TicketPeople.Where(t => t.TicketId == ticketId)
                    .Where(t => personIds.Contains( (int) t.PersonId)).ToList()
                    .ForEach(t => db.TicketPeople.Remove(t));
                    db.SaveChanges();
            }
