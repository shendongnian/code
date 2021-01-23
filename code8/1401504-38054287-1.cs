    2: Barney
    4: Betty  
---
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    
    class Program
    {
        static void Main()
        {
            // reset and populate
            using (var conn = GetConnection())
            {            
                conn.Open();
                try { conn.Execute(@"drop table FooActors;"); } catch { }
                conn.Execute(@"create table FooActors (
                    Id int not null primary key identity(1,1),
                    Name nvarchar(50) not null);");
                conn.Execute(@"insert FooActors(Name) values(@Name);", new[]
                {
                    new { Name = "Fred" },
                    new { Name = "Barney" },
                    new { Name = "Wilma" },
                    new { Name = "Betty" },
                });
            }
    
            // run a demo query
            var tags = new[] { "Barney", "Betty" };
            var query = new ListMembersQuery { Tags = tags };
            var actors = SearchMembersInLists(query);
            foreach(var actor in actors)
            {
                Console.WriteLine("{0}: {1}", actor.Id, actor.Name);
            }
        }
        public static IDbConnection GetConnection()
        {
            return new SqlConnection(
                @"Initial Catalog=master;Data Source=.;Integrated Security=SSPI;");
        }
        public class ActorDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class ListMembersQuery
        {
            public string[] Tags { get; set; }
        }
        public static IEnumerable<ActorDto> SearchMembersInLists(ListMembersQuery query)
        {
            IEnumerable<ActorDto> result = null;
            const string sql = @"select Id, Name from FooActors where Name IN @Tags";
            using (var cnx = GetConnection())
            {
                cnx.Open();
                var query_result = cnx.QueryMultiple(sql, new { query.Tags });
                result = query_result.Read<ActorDto>();
            }
    
            return result;
        }
    }
