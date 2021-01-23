    public DataSet Getdata(string IdModel)
    {
     if (IdModel!= null)
        if (IdModel.Trim() != "")
        {
            yourquery= yourquery.Where(c => c.IdModel== IdModel.Trim());
        }
    //and so on
    }
