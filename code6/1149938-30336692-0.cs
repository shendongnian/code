    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication6
    {
        public class Transactions
        {
            public string CreateDate { get; set; }
            public string Name { get; set; }
            public int Unit { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var transactionsList = new List<Transactions>();
                transactionsList.Add(new Transactions() { CreateDate = "2015-01-01", Name = "Users", Unit = 100 });
                transactionsList.Add(new Transactions() { CreateDate = "2015-01-01", Name = "Items", Unit = 50 });
                transactionsList.Add(new Transactions() { CreateDate = "2015-01-02", Name = "Users", Unit = 400 });
                transactionsList.Add(new Transactions() { CreateDate = "2015-01-02", Name = "Items", Unit = 150 });
                transactionsList.Add(new Transactions() { CreateDate = "2015-01-02", Name = "NewItems", Unit = 600 });
                var dictionaryList = new List<Dictionary<string, object>>();
                var transactionsQuery = (from t in transactionsList
                                         group t by new { t.CreateDate, t.Name }
                                             into grp
                                             select new
                                             {
                                                 grp.Key.CreateDate,
                                                 grp.Key.Name,
                                                 Units = grp.Sum(t => t.Unit)
                                             }).ToList();
                var days = (from t in transactionsList
                            group t by new { t.CreateDate }
                                into grp
                                select grp.Key.CreateDate).ToList();
                foreach (string day in days)
                {
                    var dataOfDay = new Dictionary<string, object>();
                    dataOfDay.Add("CreateDate", day);
                    foreach (var transaction in transactionsQuery.Where(x => x.CreateDate == day))
                    {
                        dataOfDay.Add(transaction.Name, transaction.Units);
                    }
                    dictionaryList.Add(dataOfDay);
                }
                Console.WriteLine(JsonConvert.SerializeObject(dictionaryList));
                Console.ReadLine();
                // Output :
                // [{"CreateDate":"2015-01-01","Users":100,"Items":50},{"CreateDate":"2015-01-02","Users":400,"Items":150,"NewItems":600}]
            }
        }
    }
