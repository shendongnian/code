private void populateTreeView(TreeView tv) 
{ 
	try 
		{ 
			String query = "select * from year_grade order by sort asc"; 
			cmd = new MySqlCommand(query, conn); 
			dr = cmd.ExecuteReader(); 
			String query1 = ""; 
			while (dr.Read()) 
			{ 
				TreeNode node = new TreeNode(dr["year_grade"].ToString()); 
				query1 = "select * from stud_year where year_grade='" + dr["year_grade"] + "' "; 
				cmd2 = new MySqlCommand(query1, conn); 
				dr2 = cmd2.ExecuteReader(); 
				while (dr2.Read()) 
				{ 
					node.Nodes.Add(dr2["stud_year"].ToString()); 
					tv.Nodes.Add(node); 
				} 
                                dr2.Close();
			} 
			
			dr.Close();
                        conn.Close(); 
		}
		catch (Exception n)
        {
            Console.Write(n.Message);
            MessageBox.Show(n.Message);
        }
 }
