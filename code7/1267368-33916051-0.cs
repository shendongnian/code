        String queryString =
            @"declare
                 xml_ xmltype := xmltype('<root></root>');
                begin
                 :par := xml_;
                end;";
        using (OracleConnection connection = new OracleConnection(source))
        {
            OracleCommand command = new OracleCommand(queryString, connection);
            connection.Open();
            var res = command.Parameters.Add("par", OracleDbType.XmlType, ParameterDirection.Output);
            command.ExecuteNonQuery();
            MessageBox.Show(((Oracle.DataAccess.Types.OracleXmlType)(res.Value)).Value);
        }
