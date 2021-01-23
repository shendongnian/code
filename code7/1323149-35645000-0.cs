        using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication3
    {
    
        public class Transactions
        {
            public string Month { get; set; }
            public string Cath { get; set; }
            public string Year { get; set; }
            public int Unit { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var transactionsList = new List<Transactions>();
                transactionsList.Add(new Transactions() { Month = "Jan", Cath = "A", Year = "pre", Unit = 10 });
                transactionsList.Add(new Transactions() { Month = "Jan", Cath = "A", Year = "cur", Unit = 100 });
                transactionsList.Add(new Transactions() { Month = "Jan", Cath = "B", Year = "pre", Unit = 20 });
                transactionsList.Add(new Transactions() { Month = "Jan", Cath = "B", Year = "cur", Unit = 200 });
                transactionsList.Add(new Transactions() { Month = "Jan", Cath = "C", Year = "pre", Unit = 30 });
                transactionsList.Add(new Transactions() { Month = "Jan", Cath = "C", Year = "cur", Unit = 300 });
                transactionsList.Add(new Transactions() { Month = "Jan", Cath = "D", Year = "pre", Unit = 40 });
                transactionsList.Add(new Transactions() { Month = "Jan", Cath = "D", Year = "cur", Unit = 400 });
                transactionsList.Add(new Transactions() { Month = "Feb", Cath = "B", Year = "pre", Unit = 50 });
                transactionsList.Add(new Transactions() { Month = "Feb", Cath = "B", Year = "cur", Unit = 500 });
    
    
                var transactionsQuery =
                    (from t in transactionsList
                    group t by t.Month into newGroup
                    orderby newGroup.Key descending
                    select newGroup).ToList();
    
    
                var dictionaryList = new List<Dictionary<string, object>>();
    
                foreach (var nameGroup in transactionsQuery)
                {
                    var data = new Dictionary<string, object>();
                    data.Add("name", nameGroup.Key);
    
                    foreach (var item in nameGroup)
                    {                   
                        data.Add(string.Format("{0}{1}", item.Year, item.Cath), item.Unit);
                    }
                    dictionaryList.Add(data);
    
                }
    
               var ser = JsonConvert.SerializeObject(dictionaryList);
    
                Console.WriteLine(ser);
                Console.ReadLine();
    
            }
        }
    }
