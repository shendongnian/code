     string id;
     string literal; // "CHHRT" or whatever;
     int sequence;
     con.Open();
     string rate = "SELECT MAX(TypeID) FROM tblRoomTypeRate";
     cmd = new OleDbCommand(rate, con);
     OleDbDataReader dr = cmd.ExecuteReader();
     if (dr.Read())
     {
         id = dr[0].ToString();
         sequence = int.Parse( new string( id.Where( char.IsDigit ).ToArray() ) );
         literal = new string( id.Where( char.IsLetter ).ToArray() );
         id = literal + ( sequence++ ).ToString( "000" );                
         txtRateID.Text = id;
     }
     con.Close();
}
