    using System;
    namespace CoinpaymentsTest
    {
      class Program
      {
        static void Main(string[] args)
        {
            var cp = new Coinpayments.Coinpayments("PRIVATEKEY", "PUBLICKEY");
            var payment = cp.CreateTransactionSimple(2, "USD", "BTC");
            Console.WriteLine(payment.error);
            Console.WriteLine(payment.result.qrcode_url);
            var check = cp.GetTransactionInfo(payment.result.txn_id);
            Console.WriteLine(check.result.payment_address);
            Console.Read();
        }
      }
    }
