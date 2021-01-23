    static void Main(string[] args)
    {
        var connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\iharbahoui\Desktop\ConsoleApplication1\ConsoleApplication1\glpi.mdf;Integrated Security=True";
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var query = @"
                select t.id, 
                    case 
                        when (p.idTicket is null) then 'ticket n''existe' 
                        else 'ticket existe deja' 
                    end as ticket_exists
                from glpi_tickets t 
                left outer join AZPbd.dbo.planification p 
                    on t.id = p.idTicket
                    and p.user_id = @userId
                where t.user_id_recipient = @userId";
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@userId", 1);
            var reader = command.ExecuteReader();
            var ticketsFound = false;
            while (reader.Read())
            {
                Console.WriteLine("{0}: {1}", reader["id"], reader["ticket_exists"]);
                ticketsFound = true;
            }
            if (!ticketsFound)
                Console.WriteLine("Ticket n'existe pas");
        }
        Console.ReadKey();
    }
