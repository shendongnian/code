    string select = @"
        select 
            g.nume as Gestiune, 
            p.cod as NumarNIR, 
            p.doc_cod as DocumentDeBaza, 
            p.Validat as Validat, 
            p.Facturat as Contat 
        from 
            primar p 
                inner join gestiuni g 
                on p.part2=g.gest_id 
                    and data=@DateNIR 
                    and cod=@TextNIR";
    SqlParameter[] parameters = 
    {
        new SqlParameter("@DateNIR", dtpNIR.Value),
        new SqlParameter("@TextNIR", txtNIR.Text)
    }
    using SqlConnection conn = new SqlConnection(yourConnectionString)
    {
        using SqlCommand command = new SqlCommand(select, conn)
        {
            command.Parameters.AddRange(parameters);
            conn.Open()
            //Execute command
        }
    }
