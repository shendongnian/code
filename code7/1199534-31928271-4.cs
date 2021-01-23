    public static void SelectAllSomething(DropDownList list)
        {
            // Clear any previously bound items.
            list.Items.Clear(); 
            // SqlConnection.
            SqlConnection con = new SqlConnection(conString);
            // Create new command and parameterise.
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "MyStoredProcedure";
            cmd.Connection = con;
            try
            {
                // Open connection and bind data to GUI.
                con.Open();
                list.DataSource = cmd.ExecuteReader();
                list.DataTextField = "Name";
                list.DataValueField = "ID";
                list.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
		
		
