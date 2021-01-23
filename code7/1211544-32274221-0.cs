    Public String Get_Filed_By_Id(string table_Name,String Field_Name,string PK_val)
    {
        string strRes="";
        using(mydbcontext db=new mydbcontext())
        {
          var x=db.table_Name.Where(p=>p.Id=PK_val).Select(b=>b.Field_Name).FirstOrDefault();
          strRes=Convert.Tostring(x);
        }
     return strRes;
    }
