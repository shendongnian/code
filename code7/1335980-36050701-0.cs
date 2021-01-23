    string MyConnection1 = "datasource=localhost;port=3306;username=root;password=tactac11";
    string Query1 = "insert into myproject.song " +
                        "(song_name, house_number, song_text) " +
                      "values " +
                        "(@SongName, @HouseNum, @SongText)"; //Insert song name, song huose count and full song text
    string Query2 = "SELECT LAST_INSERT_ID()";
    string Query3 = "insert into myproject.file " +
                        "(File_Location, Words_number, Lines_number, File_name, song_id) " +
                      "values " +
                        "(@FileLoc, @WordCount, @LineCount, @FileName, @SongId";  //Insert table file details                          
    try
    {
        MySqlConnection myConn1 = new MySqlConnection(MyConnection1);
        myConn1.Open();
        MySqlCommand Cmd1 = new MySqlCommand(Query1, myConn1);
        Cmd1.Parameters.AddWithValue("@SongName", line1);
        Cmd1.Parameters.AddWithValue("@HouseNum", paragraphs.Length);
        Cmd1.Parameters.AddWithValue("@SongText", filetext);
        Cmd1.ExecuteNonQuery();
        MySqlCommand Cmd2 = new MySqlCommand(Query2, myConn1);
        object result = Cmd2.ExecuteScalar();
        int songId = Convert.ToInt32(result);
        MySqlCommand Cmd3 = new MySqlCommand(Query3, myConn1);
        Cmd3.Parameters.AddWithValue("@FileLoc", strfilename);
        Cmd3.Parameters.AddWithValue("@WordCount", words.Length);
        Cmd3.Parameters.AddWithValue("@LineCount", totallineCnt);
        Cmd3.Parameters.AddWithValue("@FileName", fileNameOnly);
        Cmd3.Parameters.AddWithValue("@SongId", songId);
        Cmd3.ExecuteNonQuery();
        myConn1.Close();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
