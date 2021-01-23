    var USR = new Users() {UserName=user};
    var PC = new Pc() {PcName=pc};    
    ptr.ToList().ForEach(p=>
        {
            var RF = new Reference() {Date=DateTime.Now};
            var PTR = new Printers() {PrinterName = p };
            PTR.Reference.Add(RF);
            USR.Reference.Add(RF);
            PC.Reference.Add(RF);
            context.Set<Pc>().Add(PC);
            context.Set<Users>().Add(USR);
            context.Set<Printers>().Add(PTR);
        });
        context.SavesChanges();
