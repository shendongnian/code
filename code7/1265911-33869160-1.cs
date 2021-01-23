        public void AuditRecord(DateTime date, String user, string[] printer, String pc)
        {
            // enumerate through printer names because each Reference only has 1 printer
            printer.ToList().ForEach(p =>
            {
                var REF = new Reference() { Date = date };
                REF.Users.Add(new Users() { UserName = user }); // add User to Reference
                REF.Pc.Add(new Pc() { PcName = pc }); // add PC to Reference
                REF.Printers.Add(new Printers() { PrinterName = p }); // add Printer to Reference
                context.Set<Reference>().Add(REF); // add Reference into context for saving
            });
            context.SaveChanges(); 
        }
