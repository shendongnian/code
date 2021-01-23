      private static void Main(string[] args) {
            var db = new MyDbContext();
            var reftable1 = new RefTable() {Id = 100, RefName = "ref1"};
            var listData1 = new List<Data>();
            for (int i=0; i<5; i++)
                listData1.Add(new Data() {Id = i, Machine =  reftable1, RefId = reftable1.Id});
            reftable1.DataDetails = listData1;
            db.RefData.Add(reftable1);
            var reftable2 = new RefTable() {Id = 200, RefName = "ref2"};
            var listData2 = new List<Data>();
            for (int i=5; i<10; i++)
                listData2.Add(new Data() {Id = i, Machine =  reftable2, RefId = reftable2.Id});
            reftable2.DataDetails = listData2;
            db.RefData.Add(reftable2);
            db.SaveChanges();
            db = new MyDbContext(); //lose connection to existing dbContext
            //now reftable1 is unattached, so if not lookup it from new dbContext it will be recreated!!!
            reftable1 = db.RefData.Single(x => x.RefName == "ref1"); //comment to see the difference
            //perform some update
            var data = db.Data.Where(x => x.Id > 7).ToList();
            foreach (var d in data) {
                d.Machine = reftable1;
            }
            db.SaveChanges();
            Console.ReadLine();
        }
