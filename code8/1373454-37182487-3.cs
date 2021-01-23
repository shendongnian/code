    string mID = txtID.Text;
    OleDbCommand command.CommandText = 
    "SELECT m.* FROM Member m, Rental r WHERE 
    	m.MemberID = r.MemberID AND 
    	m.MemberID = '" + mID + "'";
    	
    OleDbDataReader reader = command.ExecuteReader();
    if (reader.Read())
    {
    	// member found
        txtName.Text = reader["MemberName"].ToString();
        txtAdd.Text = reader["Address"].ToString();
        // query movies
    	command.CommandText = 
    	"SELECT mo.* FROM Member m, Movies mo, Rental r WHERE 
    		m.MemberID = r.MemberID AND 
    		r.DVDnumber = mo.DVDnumber AND 
    		m.MemberID = '" + mID + "'";
    
    	raeder = command.ExecuteReader();
    	string movies;
    	while (raeder.Read())
    	{
    		// multiple rentals possible?!
    		movies += raeder["MovieTitle"].ToString() + '\n';
    	}
    	txtMovieT.Text = movies;
    }
