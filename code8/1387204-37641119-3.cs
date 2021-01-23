    static async Task OnQueryReceived(object sender, QueryReceivedEventArgs e)
            {
                DnsMessage query = e.Query as DnsMessage;
                if (query == null) return;
                DnsMessage response = query.CreateResponseInstance();
    
                if (response.Questions.Any())
                {
                    DnsQuestion question = response.Questions[0];
                    DnsMessage upstreamResponse = await DnsClient.Default.ResolveAsync(question.Name, question.RecordType, question.RecordClass);
    
                    response.AdditionalRecords.AddRange(upstreamResponse.AdditionalRecords);
                    response.ReturnCode = ReturnCode.NoError;
    
                    if (!question.Name.ToString().Contains("yourdomain.com"))
                    {
                        response.AnswerRecords.AddRange(upstreamResponse.AnswerRecords);
                    }
                    else
                    {
                        response.AnswerRecords.AddRange(
                            upstreamResponse.AnswerRecords
                                .Where(w => !(w is ARecord))
                                .Concat(
                                    upstreamResponse.AnswerRecords
                                        .OfType<ARecord>()
                                        .Select(a => new ARecord(a.Name, a.TimeToLive, IPAddress.Parse("192.168.0.199"))) // some local ip address
                                )
                        );
                    }
    
                    e.Response = response;
                }
            }
