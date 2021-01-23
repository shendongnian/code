    using System;
    using System.Web.Script.Serialization;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            private const string Json = @"{
            ""SaveData"": {
            ""TransactionType"": ""2"",
            ""Date"": ""8/10/2016"",
            ""BankAccountID"": ""449"",
            ""PaidTo"": ""Cash"",
            ""Amount"": ""1551"",
            ""CheckNumber"": ""51451"",
            ""SupportingDocNo"": ""51521"",
            ""Remarks"": ""This is a remarks & this contains special character"",
            ""CheckPaymentID"": 0
        },
        ""Type"": ""Save""}";
    
            static void Main(string[] args)
            {
                try
                {
                    var data = new JavaScriptSerializer().Deserialize<CheckPaymentsService>(Json);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    
        public class CheckPaymentsService
        {
            public SaveData SaveData { get; set; }
            public string Type { get; set; }
        }
    
        public class SaveData
        {        
            public int TransactionType { get; set; }
            public DateTime Date { get; set; }
            public int BankAccountID { get; set; }
            public string PaidTo { get; set; }
            public int Amount { get; set; }
            public int CheckNumber { get; set; }
            public int SupportingDocNo { get; set; }
            public string Remarks { get; set; }
            public int CheckPaymentID { get; set; }
        }
    }
