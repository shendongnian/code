    static void Parametri(NpgsqlCommand cmd, bool justId)
        {
            cmd.Parameters.Add(new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id"));
            if(justId){return;}
            cmd.Parameters.Add(new NpgsqlParameter("@nosaukums", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "nosaukums"));
            cmd.Parameters.Add(new NpgsqlParameter("@svars", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "svars"));
            cmd.Parameters.Add(new NpgsqlParameter("@marka", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "marka"));
            cmd.Parameters.Add(new NpgsqlParameter("@modelis", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "modelis"));
            cmd.Parameters.Add(new NpgsqlParameter("@sedvietas", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "sedvietas"));
        }
