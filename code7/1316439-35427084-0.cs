    static void getDistinct()
        {
            using (ClusterResultDBDataContext db = new ClusterResultDBDataContext())
            {
                var result = new LinkedList<Tuple<int, int>>();
                using (var sw = new StreamWriter("result.txt"))
                {
                    var results = db.Results;
                    foreach (var y in results)
                    {
                        var cnarr = y.PaperResults
                        .OrderBy(x => x.DOI)
                        .Select(x => x.ClusterNumber).ToArray();
                        var re = cnarr.Aggregate((x, a) => (x * 10 + a) % 19930727);
                        Console.WriteLine(y.ID + " " + re);
                        sw.WriteLine(y.ID + "," + re);
                    }
                }
            }
        }
