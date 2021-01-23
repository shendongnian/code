    public class BikeViewModel
    {
        public DateTime Date { get; set; }
        public int StaffNo { get; set; }
        public string File { get; set; }
        public string CrimeRef { get; set; }
    }
    ...
    var bikes = (from b in xml.Descendants("Photo")
                select new BikeViewModel
                {
                     Date = (DateTime)b.Element("Date"),
                     StaffNo = (Int32)b.Element("StaffNo"),
                     File = (string)b.Element("File"),
                     CrimeRef = (string)b.Element("CrimeRef")
                }).ToList();
    
    return View(bikes);
