    using System.Collections.Generic;
    namespace ConsoleApplication1
    {
        class Program
        {        
            static void Main(string[] args)
            {
                List<projects> projInfo = new List<projects>();
                projInfo.Add(new projects("1", "1", "1"));
                projInfo.Add(new projects("2", "2", "2"));
                projInfo[0].siteInfo.Add(new sites("10", "10", "10"));
                projInfo[0].siteInfo.Add(new sites("20", "20", "20"));
                projInfo[1].siteInfo.Add(new sites("30", "30", "30"));
                projInfo[1].siteInfo[0].well_list.Add(new wells("100", "100", "100"));
            }
        }
        public class wells
            {
                public string c_wellname { get; set; }
                public string well_id { get; set; }
                public string site_id { get; set; }
                public wells(string c_wellname, string well_id,string site_id)
                {
                    this.c_wellname = c_wellname;
                    this.well_id = well_id;
                    this.site_id = site_id;
                }
            }
            public class sites
            {
                public string c_wellname { get; set; }
                public string site_id { get; set; }
                public string project_id { get; set; }
                public List<wells> well_list { get; set; } //new property
                public sites(string c_wellname, string site_id, string project_id)
                {
                    this.c_wellname = c_wellname;
                    this.site_id = site_id;
                    this.project_id = project_id;
                    well_list = new List<wells>(); //init the property
                }
            }
            public class projects
            {
                public string project_name { get; set; }
                public string project_id { get; set; }
                public string site_id { get; set; }
                public List<sites> siteInfo { get; set; } //new property
                public projects(string project_name, string project_id, string site_id)
                {
                    this.project_name = project_name;
                    this.project_id = project_id;
                    this.site_id = site_id;
                    siteInfo = new List<sites>(); //init the property
                }
            }
    }
