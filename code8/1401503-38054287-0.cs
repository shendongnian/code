    public static IEnumerable<ActorDto> SearchMembersInLists(ListMembersQuery query)
    {
        using (var cnx = GetConnection())
        {
            return cnx.Query<ActorDto>(
                @"select Id, Name from FooActors where Name IN @Tags", new { query.Tags });
        }
    }
