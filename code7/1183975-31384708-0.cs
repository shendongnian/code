    public static IEnumerable<String> AccountNames() {
      //TODO: Move it into Settings/Config... 
      String connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Users.mdf;Integrated Security=True;Connect Timeout=30";
    
      // Dispose (via using) all Disposable...  
      using (SqlConnection connection = new SqlConnection(connectionString)) {
        connection.Open();
    
        // Dispose: prevent resource leakage...
        using (SqlCommand command = new SqlCommand("SelectAllUsers", connection)) {
          using (SqlDataReader usersReader = command.ExecuteReader()) {
            while (usersReader.Read())
              yield return (string)usersReader["Username"];
          }
        } 
      }
    }
    
    // returns selected profile 
    // or null if no profile was seelcted
    public static string SelectProfile() {
      // var: You need Select_Profile, not just a Form, right?
      // again (using): don't forget to clear up the resources
      using (var selectProfile = new Select_Profile()) {
        // Providing that comboboxWrapper is public (bad practice) 
        // or SelectProfile() is implemented within Select_Profile class (good   one) 
        selectProfile.comboboxWrapper.Items.AddRange(AccountNames());
    
        if (selectProfile.comboboxWrapper.Items.Count > 0)
          selectProfile.comboboxWrapper.SelectedIndex = 0;
    
        if (selectProfile.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
          if (selectProfile.comboboxWrapper.SelectedIndex < 0)
            return null; // No item to select
          else
            selectProfile.comboboxWrapper.SelectedItem.ToString();
        }
        else 
          return null; // Just closed
      }
    }
