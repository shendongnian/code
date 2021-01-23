    public async Task<ISuggestResponse> Suggest(string index, string field, string text)
        {
            var suggestResponse = await _client.SuggestAsync<TDocument>(s => s
                  .Index(index)
                  .Completion("suggest", c => c
                        .Text(text)
                        .Context(con => con.Add("your_field", "text"))
                        .Field(field)
                        .Size(20)
                  )
            );
    
            return suggestResponse;
        }
