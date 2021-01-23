               DataTable dtCategory = new DataTable();
    
                int CategoryID = 0;
                SqlConnection conn = new SqlConnection(connectionString);
                string query = "Select * from TBLCATEGORIES where SubCategoryID = " + CategoryID;
    
                SqlCommand cmd = new SqlCommand(query, conn);
    
                using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                {
                    a.Fill(dtCategory);
                }
    
                foreach (var subCategories  in dtCategory.Rows)
                {
                   
                       // your logic goes here
                    
                }
