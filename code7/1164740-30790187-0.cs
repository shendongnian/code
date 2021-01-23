    using System;
    using System.Data;
    using System.Data.SqlClient;
    
    SqlConnection conn = new SqlConnection(***Your Connection String Here***);
    conn.Open();
    
    SqlDataAdapter adpt = new SqlDataAdapter("Select ID, Dish, Price From RestaurantMenu", conn);
    
    DataTable dt = new DataTable();
    adpt.fill(dt);
    
    foreach (DataRow dr in dt.Rows){
    
         console.WriteLine(dr["ID"].ToString() + " | " + dr["Dish"].ToString() + " | " + dr["Price"].ToString());
    
    }
