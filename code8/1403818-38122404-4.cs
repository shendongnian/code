    int ID=1;
    while (reader.Read())
    {
       ID++;
       Control tituloControl= Page.FindControl("Titulo"+ID");
       if(tituloControl!=null) 
       {
          tituloControl.ID=" Titulo"+ID;           
          tituloControl.Text= reader["Titulo"].ToString();
       } 
       Control GeneroControl= Page.FindControl("Genero"+ID");
       if(GeneroControl!=null) 
       {
          GeneroControl.ID=" Genero"+ID;           
          GeneroControl.Text= reader["GeneroControl"].ToString();
       }
    }
