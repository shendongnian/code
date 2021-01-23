    int ID = 0;
    while (reader.Read())
    {
       ID++;
       Label tituloControl= (Label) Page.FindControl("Titulo"+ID);
       if(tituloControl!=null) 
       {         
          tituloControl.Text= reader["Titulo"].ToString();
       } 
       Label GeneroControl= (Label) Page.FindControl("Genero"+ID);
       if(GeneroControl!=null) 
       {       
          GeneroControl.Text= reader["NomeGenero"].ToString();
       }
    }
