    DataTable dt=new DataTable();
    dt.Columns.Add("Data1");
    dt.Columns.Add("Data2");
    dt.Columns.Add("Data3");
    DataRow drow=dt.NewRow();
    for(int i=1;i<olddt.Rows.Count;i++)
    {
      if(i%3==0 && i!=0)
      {
         dt.Rows.Add(drow); 
         drow=dt.NewRow();
      }
      if(i%3==0)
      {
        drow[0]=olddt[i][Column].ToString();
      }
      if(i%3==1)
      {
         drow[1]=olddt[i][Column].ToString();
      }
      if(i%3==2)
      {
        drow[2]=olddt[i][Column].ToString();
      }
    }
