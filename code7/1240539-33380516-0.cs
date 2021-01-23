    private void Form1_Load(object sender, EventArgs e)
    {
        //Form2 frm = new Form2();
        //frm.Show();
        users_ofTableAdapter.Fill(this.karvanDataSet.Users_of, 1);
        // Config data adapter for updating database
        SqlConnection connection = new SqlConnection(Settings.Default.KarvanConnectionString);
        String sqlInsert = "INSERT INTO [dbo].[Users] ([Firstname], [Lastname], [Fathername], [CodeMelli], [Tel], [Mobile], [Tahol], [ImagePath]) VALUES (@Firstname, @Lastname, @Fathername, @CodeMelli, @Tel, @Mobile, @Tahol, @ImagePath)";
        String sqlUpdate = "UPDATE [dbo].[Users] SET [Firstname] = @Firstname, [Lastname] = @Lastname, [Fathername] = @Fathername, [CodeMelli] = @CodeMelli, [Tel] = @Tel, [Mobile] = @Mobile, [Tahol] = @Tahol, [ImagePath] = @ImagePath WHERE ([Id] = @Original_Id)";
        String sqlDelete = "DELETE FROM [dbo].[Users] WHERE (([Id] = @Original_Id)";
        SqlCommand cmdInsert = new SqlCommand(sqlInsert, connection);
        SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, connection);
        SqlCommand cmdDelete = new SqlCommand(sqlDelete, connection);
        SqlParameter myparam = new SqlParameter();
        cmdInsert.Parameters.Add("@Firstname", SqlDbType.NVarChar, 30, "Firstname");
        cmdInsert.Parameters.Add("@Lastname", SqlDbType.NVarChar, 30, "Lastname");
        cmdInsert.Parameters.Add("@Fathername", SqlDbType.NVarChar, 30, "Fathername");
        cmdInsert.Parameters.Add("@CodeMelli", SqlDbType.NVarChar, 30, "CodeMelli");
        cmdInsert.Parameters.Add("@Tel", SqlDbType.NVarChar, 30, "Tel");
        cmdInsert.Parameters.Add("@Mobile", SqlDbType.NVarChar, 30, "Mobile");
        cmdInsert.Parameters.Add("@Tahol", SqlDbType.TinyInt, 1, "Tahol");
        cmdInsert.Parameters.Add("@ImagePath", SqlDbType.NVarChar, 30, "ImagePath");
        //cmdInsert.Parameters.Add("@DateAdded", SqlDbType.DateTime, "DateAdded");
        cmdUpdate.Parameters.Add("@Firstname", SqlDbType.NVarChar, 30, "Firstname");
        cmdUpdate.Parameters.Add("@Lastname", SqlDbType.NVarChar, 30, "Lastname");
        cmdUpdate.Parameters.Add("@Fathername", SqlDbType.NVarChar, 30, "Fathername");
        cmdUpdate.Parameters.Add("@CodeMelli", SqlDbType.NVarChar, 30, "CodeMelli");
        cmdUpdate.Parameters.Add("@Tel", SqlDbType.NVarChar, 30, "Tel");
        cmdUpdate.Parameters.Add("@Mobile", SqlDbType.NVarChar, 30, "Mobile");
        cmdUpdate.Parameters.Add("@Tahol", SqlDbType.TinyInt, 1, "Tahol");
        cmdUpdate.Parameters.Add("@ImagePath", SqlDbType.NVarChar, 30, "ImagePath");
        //cmdUpdate.Parameters.Add("@DateAdded", SqlDbType.DateTime, "DateAdded");
        cmdUpdate.Parameters.Add("@Original_Id", SqlDbType.Int, 2, "id");
        cmdDelete.Parameters.Add("@Original_Id", SqlDbType.Int, 2, "id");
        users_ofTableAdapter.Adapter.InsertCommand = cmdInsert;
        users_ofTableAdapter.Adapter.UpdateCommand = cmdUpdate;
        users_ofTableAdapter.Adapter.DeleteCommand = cmdDelete;
    }
    private void btnSave_Click(object sender, EventArgs e)
    {
        users_ofTableAdapter.Adapter.Update(karvanDataSet);
    }
