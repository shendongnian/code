        DnsMessage upstreamResponse = await DnsClient.Default.ResolveAsync(question.Name, question.RecordType, question.RecordClass);
        foreach (DnsRecordBase record in upstreamResponse.AnswerRecords)
        {
            var toAdd = record;
            var arecord = toAdd as ARecord;
            if (arecord != null && question.Name.ToString().Contains("thedomainthatyouwant.com"))
            {
                toAdd = new ARecord(arecord.Name, arecord.TimeToLive, IPAddress.Parse("192.168.0.199")); //some local network ip address
            }
            response.AnswerRecords.Add(toAdd);
        }
        foreach (DnsRecordBase record in (upstreamResponse.AdditionalRecords))
        {
            response.AdditionalRecords.Add(record);
        }
        response.ReturnCode = ReturnCode.NoError;
        e.Response = response;
