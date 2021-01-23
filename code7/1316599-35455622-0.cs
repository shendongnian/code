    public class sortList
            {
                public string Layer { get; set; }
                public string mlenth { get; set; }
                public string diameter { get; set; }
                public string subtypecd { get; set; }
                public string coatingtype { get; set; }
                public string year { get; set; }
                public string gisid { get; set; }
                public string taxdistrict { get; set; }
                public string lengthsource { get; set; }
                public string shapelen { get; set; }
                public string feet { get; set; }    
    
                public sortList()
                {
                    this.Layer = ListSortDirection.Ascending.ToString();
                    this.mlenth = ListSortDirection.Ascending.ToString();
                    this.feet = ListSortDirection.Ascending.ToString();
                    this.diameter = ListSortDirection.Ascending.ToString();
                    this.subtypecd = ListSortDirection.Ascending.ToString();
                    this.coatingtype = ListSortDirection.Ascending.ToString();
                    this.year = ListSortDirection.Ascending.ToString();
                    this.gisid = ListSortDirection.Ascending.ToString();
                    this.taxdistrict = ListSortDirection.Ascending.ToString();
                    this.lengthsource = ListSortDirection.Ascending.ToString();
                    this.shapelen = ListSortDirection.Ascending.ToString();
                }
            }
