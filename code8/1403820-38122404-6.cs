    int ID=1;
    while (reader.Read())
    {
       ID++;
       Label tituloControl= Page.FindControl("Titulo"+ID") as Label;
       if(tituloControl!=null) 
       {
          tituloControl.ID=" Titulo"+ID;           
          tituloControl.Text= reader["Titulo"].ToString();
       } 
       Label GeneroControl= Page.FindControl("Genero"+ID") as Label;
       if(GeneroControl!=null) 
       {
          GeneroControl.ID=" Genero"+ID;           
          GeneroControl.Text= reader["GeneroControl"].ToString();
       }
    }
