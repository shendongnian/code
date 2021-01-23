    for(int i=1; i<=Convert.ToInt32(Session["count"]) ;i++)
           {
               SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CM_Connection"].ConnectionString);
               conn.Open();
               item items = new item();
               items.Id = Session["id" + i].ToString();
               string checkuser = "select prod_name from productt where prod_id=" + Convert.ToInt32(Session["id" + i]) ;
               SqlCommand com = new SqlCommand(checkuser, conn);
               string temp= (com.ExecuteScalar()).ToString();
               items.Name = temp;
    
               
             
    
    
    
               li.Add(items);
    
           }
