    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Contractors> contractors = new List<Contractors>() {
                    new Contractors() { ContractorName = "Panhandle Mental Health Center - Sidney", ParentName = "Panhandle Mental Health Ctr/Region 1"},
                    new Contractors() { ContractorName = "Panhandle Mental Health Center - Sidney", ParentName = "Panhandle Mental Health Ctr/Region 1"},
                    new Contractors() { ContractorName = "Panhandle Mental Health Ctr/Region 1"},
                    new Contractors() { ContractorName = "Region 1 - Panhandle Prevention Coalition", ParentName = "Panhandle Mental Health Ctr/Region 1"},
                    new Contractors() { ContractorName = "Region 1 Behavioral Health - Ave. D. Scottsbluff",ParentName = "Region 1 Behaviorial Health Authority"},
                    new Contractors() { ContractorName = "Region 1 Behavioral Health Authority"},
                    new Contractors() { ContractorName = "Region 1 Behavioral Health Authority - 16 St Scottsbluff", ParentName = "Region 1 Behaviorial Health Authority"},
                };
                contractors.Sort((x,y) => x.CompareTo(y));
            }
        }
        public class Contractors : IComparable< Contractors>
        {
            public string ContractorName { get; set; }
            public string ParentName { get; set; }
            public int CompareTo(Contractors contractor)
            {
                if (this.ContractorName == null || this.ContractorName.CompareTo(contractor.ContractorName) == 1)
                    return 1;
                if (contractor.ContractorName == null || this.ContractorName.CompareTo(contractor.ContractorName) == -1)
                    return -1;
                if (this.ParentName == null || this.ParentName.CompareTo(contractor.ParentName) == 1)
                    return 1;
                if (this.ParentName == null || this.ParentName.CompareTo(contractor.ParentName) == -1)
                    return -1;
                return 0;
            }
            
        }
    }
    ​
