    public Section GetSectionById(int id)
    {
        DbDataReader dr = Consult.returnData("Select  id, seccion from seccionespdf where id = " + id);
        Section Sec = new Section();    
        while (dr.Read())
        {
            Sec.id = int.Parse(dr[0].ToString());
            Sec.seccion = dr[1].ToString();
    
            
        }
        return Sec;
    }
