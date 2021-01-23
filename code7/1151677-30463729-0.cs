    Module Module1
        Private Class Together
            Public Property Person As Person
            Public Property Movie As Movie
        End Class
        Sub Main()
            Dim user = "neo4j"
            Dim pwd = "password"
            Dim server = "localhost:7474"
            Dim link = "http://{0}:{1}@{2}/db/data"
            Dim url As New Uri(String.Format(link, user, pwd, server))
            Dim client As New GraphClient(url)
            client.Connect()
            Dim query = New CypherFluentQuery(client) _
                    .Match("(p:Person {name: ""Tom Hanks""})-[:ACTED_IN]->(m:Movie)") _
                    .Return(Function(p, m) New Together With {
                        .Person = p.As(Of Person)(), _
                        .Movie = m.As(Of Movie)()
                    })
            Dim results = query.Results.ToList()
            For Each item In results
                Dim temp As String = String.Format("{0} - {1}<br>", item.Movie.title, item.Movie.released)
                Console.WriteLine(temp)
            Next
            Console.ReadLine()
        End Sub
    End Module
