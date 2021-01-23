    var response = await client.SearchAsync<object>(s => s
        // specify a scroll time of 2 minutes using Time type
        .Scroll(new Time(2, Nest.TimeUnit.Minute))
        .Sort(ss => ss
             // sorting on "_doc"
            .Ascending(SortSpecialField.DocumentIndexOrder)
        )
    );
