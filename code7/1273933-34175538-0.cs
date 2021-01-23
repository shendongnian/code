        public class Products
        {
            public int pdid { get; set; }
            public string pdname { get; set; }
        }
       public class Votes
        {
            public int pdid { get; set; }
            public string cust { get; set; }
            public int vt { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                List<Products> pd = new List<Products>()
	            {
		            new Products{pdid=1, pdname="abc"},
		            new Products{pdid=2, pdname="ghi"},
		            new Products{pdid=3, pdname="mnp"},
		            new Products{pdid=4, pdname="pqr"},
		            new Products{pdid=5, pdname="xyz"}
		
	            };
                List<Votes> vt = new List<Votes>()
                {
                    new Votes{pdid=1,cust="c1",vt=2},
                    new Votes{pdid=2,cust="c1",vt=2},
                    new Votes{pdid=1,cust="c2",vt=2},
                    new Votes{pdid=3,cust="c2",vt=2},
                    new Votes{pdid=4,cust="c2",vt=2},
                    new Votes{pdid=2,cust="c3",vt=2},
                    new Votes{pdid=5,cust="c3",vt=2}
                };
                var UserId = "c3";
                var query = (from vv in vt
                             join pp in pd
                                 on vv.pdid equals pp.pdid
                             join vvv in vt
                                 on vv.pdid equals vvv.pdid
                             where !(vt.Where(c => c.cust == UserId)
                                 .Select(c => c.pdid).ToList())
                                 .Contains(vv.pdid) && (vv.cust == vvv.cust)
                             select new
                             {
                                 pdid = vv.pdid,
                                 pdname = pp.pdname
                             }).Distinct();
                foreach (var p in query)
                {
                    Console.WriteLine(p.pdid + "-" + p.pdname);
                }
                Console.ReadLine();
            }
        }
