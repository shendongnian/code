    using(SqlDataReader check = check_user.ExecuteReader())
    {
        while (check.Read())
        {
            if (Convert.ToString(check[0]) == UserEmail.Text)
            {
                MessageBox.Show("The email you entered already exists in the system.");
                exists = true;
                break;
            }
        }
    }
