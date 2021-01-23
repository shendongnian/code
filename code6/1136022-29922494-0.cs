    string strQuery = "UPDATE " + DB_TABLENAME + "  SET " +
     "LLEGADA = CONVERT(smalldatetime, @LLEGADA, 126), " +
     "SALIDA = CONVERT(smalldatetime, @SALIDA, 126) " +
     "WHERE ID_RESERVA = @ID_RESERVA";
    
     SqlCommand cmd = new SqlCommand(strQuery, con); // con = SqlConnection
     cmd.Parameters.Add("@ID_RESERVA", SqlDbType.Int);
     cmd.Parameters.Add("@LLEGADA", SqlDbType.SmallDateTime);
     cmd.Parameters.Add("@SALIDA", SqlDbType.SmallDateTime);
    
     cmd.Parameters["@ID_RESERVA"].Value = Convert.ToInt32(stringWithIdReserva);
     cmd.Parameters["@LLEGADA"].Value = stringWithLLegada.Replace(" ", "T"); //Real string value: "2015-03-30 00:00:00"
     cmd.Parameters["@SALIDA"].Value = stringWithSalida.InnerText.Replace(" ", "T"); //Real string value: "2015-04-01 00:00:00"
    
      try
      {
          cmd.ExecuteNonQuery();
      }
      catch (SqlException ex)
      {
          Console.WriteLine(ex.Message);
      }
