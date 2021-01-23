    int ID=1;
    while (reader.Read())
    {
       ID++;
       Label TituloLabel= new Label();
       TituloLabel.ID=" Titulo"+ID;
       TituloLabel.Text= reader["Titulo"].ToString();
    
       Label GeneroLabel= new Label();
       GeneroLabel.ID=" Genero"+ID;
       GeneroLabel.Text= reader["NomeGenero"].ToString();
    
       Page.Controls.Add(TituloLabel);
       Page.Controls.Add(GeneroLabel);
    }
