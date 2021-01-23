    // bear in mind, this code doesn't (necessarily) need to be in a
    //  method marked "async". If you want to await on resultsTask, though,
    //  it would need to be in an async method.
    var tasks = myData
        .Select(x => new FormUrlEncodedContent(x)) //  IEnumerable<FormUrlEncodedContent>
        .Select(x => client.PostAsync("/mydata", x)) // IEnumerable<Task<HttpResponseMessage>>
        .Select(x => ReadResultAsync(x)) // IEnumerable<Task<string>>
        .ToArray(); // Task<string>[]
    var resultsTask = Task.WhenAll(tasks); // here is Task<string[]>
