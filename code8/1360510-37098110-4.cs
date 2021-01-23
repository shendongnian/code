        var myTicket = new MyTicket()
        {
            Username = "username",
            Issued = DateTime.Now,
            Expires = DateTime.Now.AddHours(8),
            TicketExpires = DateTime.Now.AddMinutes(1)
        };
        using (var ms = new MemoryStream()) {
            new BinaryFormatter().Serialize(ms, myTicket);
            var token = Convert.ToBase64String(MachineKey.Protect(ms.ToArray(), "auth"));
        }
