    private async Task<HttpResponseMessage> ProcessMemberAsync(Member member, HttpClient client)
    {
      var response = await PostMemberAsync(member, client);
      return await ProcessResponseAsync(response, client);
    }
    private async Task AddMembersAsync(List<Member> members)
    {
      using(var client = new HttpClient())
      {
        ... // Initialize HttpClient
        var responses = await Task.WhenAll(members.Select(x => ProcessMemberAsync(x, client)));
        for (int i = 0; i != members.Count; ++i)
        {
          var member = members[i];
          var response = responses[i];
          ...
        }
      }
    }
