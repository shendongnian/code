    using (SqlDataReader reader = cmd.ExecuteReader()){
        using (SqlDataReader reader1 = cmd1.ExecuteReader()){
            using (DataTable dt = new DataTable()){
                using (DataTable dt1 = new DataTable()){
                    dt.Load(reader);
                    dt1.Load(reader1);
                    using (StreamWriter writer = new StreamWriter(Response.OutputStream)){
                         DataConvert.ToCSV(dt, writer, false);
                         DataConvert.ToCSV(dt1, writer, false);
                         ...
        }}}}}
