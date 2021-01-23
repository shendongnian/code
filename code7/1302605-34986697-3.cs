    public class PrinterFactory : Factory<Printer>
    {
        public List<Printer> Printers = new List<Printer>();
        public override IEnumerable<Printer> DeviceCollection => Printers;
        public override void Add(Printer added) { Printers.Add(added); }
    }
