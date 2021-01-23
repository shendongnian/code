        class ReadFromCsvAttribute : Attribute { }
        class OutlookModel
        {
            public int DontSetThisValueFromCsv { get; set; }
            [ReadFromCsv]
            public string FromAddress { get; set; }
            [ReadFromCsv]
            public string ToAddress { get; set; }
        }
        class SalesForceModel
        {
            [ReadFromCsv]
            public string Name { get; set; }
            [ReadFromCsv]
            public string Age { get; set; }
        }
        static void Main(string[] args)
        {
            string outlookSample = "Id,FromAddress,ToAddress,Useless\r\n" +
                                   "1,a@b.com,c@d.com,asdf\r\n" +
                                   "3,y@z.com,foo@bar.com,baz";
            string salesForceSample = "Id,Name,Age\r\n" +
                                      "1,John,30\r\n" +
                                      "2,Doe,100";
            var outlook = ReadFromCsv<OutlookModel>(outlookSample);
            var salesForce = ReadFromCsv<SalesForceModel>(salesForceSample);
        }
