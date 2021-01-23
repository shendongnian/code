        public Task<string> StoreAsync(AuthenticationTicket ticket)
        {
            string key = Guid.NewGuid().ToString();
            HttpContext httpContext = HttpContext.Current;
            CheckSessionAvailable(httpContext);
            //httpContext.Session[key + ".Ticket"] = ticket;       // Remove
            var ticketSerializer = new TicketSerializer();         // Add
            var ticketBytes = ticketSerializer.Serialize(ticket);  // Add
            httpContext.Session[key + ".Ticket"] = ticketBytes;    // Add
            return Task.FromResult(key);
        }
