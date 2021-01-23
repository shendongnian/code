    while (reader.Read())                                           /*       While there are still items to be read                       */
    {                                                               /**********************************************************************/
        cmd.Parameters.Add("@teamname", SqlDbType.VarChar);
        cmd.Parameters["@teamname"].Value = ...; // set the value here
        cmd.Parameters.Add("@date", SqlDbType.Date);
        cmd.Parameters["@date"].Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@HomeTeam", SqlDbType.VarChar, 25);
        cmd.Parameters["@HomeTeam"].Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@AwayTeam", SqlDbType.VarChar, 25);
        cmd.Parameters["@AwayTeam"].Direction = ParameterDirection.Output;
        cmd.ExecuteNonQuery();                                          /*       Execute the stored procedure                                 */
        Console.WriteLine(cmd.Parameters["@GameDate"].Value);
        Console.WriteLine(cmd.Parameters["@HomeTeam"].Value);
        Console.WriteLine(cmd.Parameters["@AwayTeam"].Value);
        Console.ReadLine(); 
    }
