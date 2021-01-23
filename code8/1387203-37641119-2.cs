    class Program
    {
        static void Main(string[] args)
        {
            using (DnsServer server = new DnsServer(System.Net.IPAddress.Any, 10, 10))
            {
                server.QueryReceived += OnQueryReceived;
                server.Start();
                Console.WriteLine("Press any key to stop server");
                Console.ReadLine();
            }
        }
        static async Task OnQueryReceived(object sender, QueryReceivedEventArgs e)
        {
            DnsMessage query = e.Query as DnsMessage;
            if (query == null)
                return;
            DnsMessage response = query.CreateResponseInstance();
            DnsQuestion question = response.Questions[0];
            DnsMessage upstreamResponse = await DnsClient.Default.ResolveAsync(!question.Name.ToString().Contains("www.google.com") ? question.Name : DomainName.Parse("www.yahoo.com"), question.RecordType, question.RecordClass);
            foreach (DnsRecordBase record in upstreamResponse.AnswerRecords)
            {
                response.AnswerRecords.Add(record);
            }
            foreach (DnsRecordBase record in (upstreamResponse.AdditionalRecords))
            {
                response.AdditionalRecords.Add(record);
            }
            response.ReturnCode = ReturnCode.NoError;
            e.Response = response;
        }
    }
