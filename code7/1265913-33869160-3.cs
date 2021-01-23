        public void AuditRecord(DateTime date, String user, string[] printer, String pc)
        {
            // enumerate through printer names because each Reference only has 1 printer
            printer.ToList().ForEach(p =>
            {
                // instantiate the instances
                var USR = new Users() { UserName = user };
                var PC = new Pc() { PcName = pc };
                var PTR = new Printers() { PrinterName = p }
                var REF = new Reference() { Date = date };
                REF.Users.Add(USR); // add User to Reference
                REF.Pc.Add(PC); // add PC to Reference
                REF.Printers.Add(PTR); // add Printer to Reference
                // add new instances into context for saving
                context.Set<Users>().Add(USR); 
                context.Set<Pc>().Add(PC); 
                context.Set<Printers>().Add(PTR); 
                context.Set<Reference>().Add(REF); 
            });
            context.SaveChanges(); 
        }
