         /// <summary>
        /// This method searches for a ticket given an ID.
        /// </summary>
        /// <param name="ticketId">Contains the ticket id to search for</param>
        /// <returns>ID of the resource.</returns>
        public Ticket FindTicket(string ticketId)
        {
           Ticket ticket = null;
            // Query Resource to get the owner of the lead
            StringBuilder strResource = new StringBuilder();
            strResource.Append("<queryxml version=\"1.0\">");
            strResource.Append("<entity>Ticket</entity>");
            strResource.Append("<query>");
            strResource.Append("<field>id<expression op=\"equals\">");
            strResource.Append(ticketId);
            strResource.Append("</expression></field>");
            strResource.Append("</query></queryxml>");
            ATWSResponse respResource = this.atwsServices.query(strResource.ToString());
            if (respResource.ReturnCode > 0 && respResource.EntityResults.Length > 0)
            {
                ticket = (Ticket)respResource.EntityResults[0];
            }
            return ticket;
        }
