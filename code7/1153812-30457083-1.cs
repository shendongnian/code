        [TestMethod]
        public void TagRepository_UpdateTicketWithTwoTagsToNone_TicketHasZeroTag()
        {
            // Arrange
            var ticketId = new Guid("54E86203-71F9-E411-80E5-000C29193DF7");
            var selectedTags = "";
            using (var context = new TicketModelContext())
            {
                var ticketToUpdate = context.Tickets.Include(t=>t.Tags).First(t => t.TicketId == ticketId);
                Assert.AreEqual(0, ticketToUpdate.Tags.Count);
                ticketToUpdate.Tags.Add(context.Tags.Find(new Guid("D1757675-A06C-4C1F-9DAD-03EE00BB1100")));
                ticketToUpdate.Tags.Add(context.Tags.Find(new Guid("96C66A97-9C3E-4B15-BD70-A4C832EEDE8B")));
                context.SaveChanges();
                var setupTicket = context.Tickets.Single(t => t.TicketId == ticketId);
                Assert.AreEqual(2, setupTicket.Tags.Count);
            }
            // Act
            new TagRepository().UpdateTicketTags(ticketId, selectedTags);
            using (var context = new TicketModelContext())
            {
                // Assert
                var updatedTeicket = context.Tickets.Include(t => t.Tags).First(t => t.TicketId == ticketId);
                Assert.AreEqual(0, updatedTeicket.Tags.Count);
            }
        }
