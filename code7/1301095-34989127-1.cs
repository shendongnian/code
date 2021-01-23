    var client = new DnsClient(servers, 10000);
    var spfRecords = client.Resolve(item.Name, RecordType.Txt);
    if (result.AnswerRecords == null || result.AnswerRecords.Count == 0 || result.ReturnCode == ReturnCode.NxDomain)
    {
        // spf record is missing
    }
    else if (result.AnswerRecords.Count == 1)
    {
        // check the record value with SpfRecord.TryParse(item.ActualValue, out spf)
    }
    else
    {
        // too many spf records
    }
    
    
    
