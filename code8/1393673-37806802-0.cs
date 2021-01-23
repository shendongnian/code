     using ()
      {
       if(Cache["mydata"]==null)
        {
                queryStr = "";
                queryStr = "select * from mydata.items;";
                cmd = new MySqlCommand(queryStr, conn);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();           
                MyAdapter.SelectCommand = cmd;        
                DataSet ds =new DataSet();
                MyAdapter.Fill(ds);
                Cache["mydata"]=ds;
                GridView1.DataSource = ds;
                GridView1.DataBind();                  
         }
    else
      {
                 GridView1.DataSource = (DataSet)Cache["mydata"];
                 GridView1.DataBind(); 
        }
    }
