    static void Main(string[] args)
        {
            ServiceReference1.CurrencyConvertorSoapClient client = new ServiceReference1.CurrencyConvertorSoapClient("CurrencyConvertorSoap");
            client.Open();
            double conversionResult = client.ConversionRate(ServiceReference1.Currency.AED, ServiceReference1.Currency.ANG);
            Console.WriteLine("{0} to {1} conversion rate is {2}", ServiceReference1.Currency.AED, ServiceReference1.Currency.ANG, conversionResult);
            client.Close();
            Console.Read();
        }
