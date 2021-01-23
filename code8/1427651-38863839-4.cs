    Random r = New Random(); // this will be global
    String colors[] = {"green", "blue", "yellow", "black"};    
    int index = r.Next(0, colors.Length);
    String colorPassword = colors[index].ToString(); // This will be the password
    // Now encrypt the password 
    byte[] byteData = System.Text.Encoding.ASCII.GetBytes(colorPassword);
    byteData = new System.Security.Cryptography.SHA256Managed().ComputeHash(byteData );
    String hashedPassword = System.Text.Encoding.ASCII.GetString(byteData );
    query = "update table set password = '" + hashedPassword + "' where username='" + your_username + "'";
    // Here you can execute the query
