    var searchQuery = new SearchRequest
    {
        Highlight = new Highlight
        {
            Fields = new FluentDictionary<Field, IHighlightField>()
                .Add(Nest.Infer.Field<Document>(d => d.Name),
                    new HighlightField {PreTags = new[] {"<tag>"}, PostTags = new[] {"<tag>"}})
        }
    };
