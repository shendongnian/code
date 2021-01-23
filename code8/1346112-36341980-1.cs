            SqlConnection conn = new SqlConnection("server=127.0.0.1; database=gimnasio5; uid=root; pwd=0000000000;");
            conn.Open();
            string query = string.Format(@"SELECT IdMembresia, Nombre, Apellido, Tipo, Fecha_Inicio,
                           Fecha_Vencimiento, Inscripcion, Total, Impreso_Corte FROM membresia where
                           Impreso_Corte = 'No impreso' or(Fecha_Membresia between '{0}' and '{1}' and
                           Hora_Membresia between '{2}' and '{3}') order by gimnasio5.membresia.IdMembresia", dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString(), dateTimePicker3.Value.ToString("hh:mm:ss"), dateTimePicker4.Value.ToString("hh:mm:ss"));
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
            return dt;
