    var result = client.Search<CorvilTest>(s => s
        .From(0)
        .Size(10000)
        .Query(x => x
            .Term(e => e.Message.EventName, "new"))); // Notice I've used "new" and not "New"
    
    var r = result.Documents;
