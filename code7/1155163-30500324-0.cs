    public partial class tbl_tech
    {
            public tbl_tech()
            {
                //this.tbl_odl = new HashSet<tbl_odl>();
                //this.tbl_pdr = new HashSet<tbl_pdr>();
            }
        
            public long IdTechnician { get; set; }
            public string DescTechnician { get; set; }
            public string LoginTechnician { get; set; }
            public string TelephoneTechnician { get; set; }
            public string SignatureTechnician { get; set; }
            public string MailTechnician { get; set; }
            public string WbsTechnician { get; set; }
            public string NumberPincerTechnician { get; set; }
            public Nullable<long> TypeTechnician { get; set; }
        
            //public virtual ICollection<tbl_odl> tbl_odl { get; set; }
            //public virtual ICollection<tbl_pdr> tbl_pdr { get; set; }
        }
