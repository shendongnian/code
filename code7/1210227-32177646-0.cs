    using System;
    using System.Linq;
    namespace Demo
    {
        class Card
        {
            public string CardID;
            public string TransactionRef;
        }
        class Transaction
        {
            public string TxnID;
            public string TxnDetails;
        }
        internal class Program
        {
            private static void Main()
            {
                var cardDetails = new[]
                {
                    new Card {CardID = "1", TransactionRef = "20150824|Guid1"},
                    new Card {CardID = "2", TransactionRef = "20150824|Guid2"},
                    new Card {CardID = "3", TransactionRef = "20150824|Guid3"}
                };
                var transDetails = new[]
                {
                    new Transaction {TxnID = "23", TxnDetails = "Guid1"},
                    new Transaction {TxnID = "24", TxnDetails = "Guid2"}
                };
                var results = cardDetails.Where(card => !transDetails.Any(trans => card.TransactionRef.EndsWith("|" + trans.TxnDetails)));
                foreach (var item in results)
                    Console.WriteLine(item.CardID + ": " + item.TransactionRef);    
            }
        }
    }
