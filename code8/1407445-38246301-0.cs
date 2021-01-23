	    private void listBox_GP_Fichiers_SelectedIndexChanged(object sender, EventArgs e)
	    {
	        // voir si il y a du personnel selectionné
	        if (listBox_GP_Fichiers.SelectedItems.Count != 0)
	        {
	            // si oui, affichage du résultat
	            string s = "";
	
	            DataTable dt = new DataTable("Personnel");
	            dt.Columns.Add("id", typeof(int));
	            dt.Columns.Add("nom", typeof(string));
	            dt.Columns.Add("prenom", typeof(string));
	            dt.Columns.Add("accelvl", typeof(string));
	            dt.Columns.Add("couleur", typeof(string));
	            dt.Columns.Add("login", typeof(string));
	            dt.Columns.Add("pass", typeof(string));
	
	            for (int x = 0; x <= listBox_GP_Fichiers.SelectedItems.Count - 1; x++)
	            {
	                s = listBox_GP_Fichiers.SelectedItems[x].ToString();
	                string aux = "";
	                aux = dataGridView_P[1, x].Value.ToString() + " " + dataGridView_P[2, x].Value.ToString();
	
	                if (s.Equals(aux))
	                {
	                    Var.GP_Id = dataGridView_P[0, x].Value.ToString();
	                    Var.GP_Nom = dataGridView_P[1, x].Value.ToString();
	                    Var.GP_Prénom = dataGridView_P[2, x].Value.ToString();
	                    Var.GP_Access_Level = dataGridView_P[3, x].Value.ToString();
	                    Var.GP_Color = dataGridView_P[4, x].Value.ToString();
	                    Var.GP_Login = dataGridView_P[5, x].Value.ToString();
	                    Var.GP_MDP = dataGridView_P[6, x].Value.ToString();
	                	
	                
	                }
	                
	                dt.AcceptChanges();
                    textBox_GP_Nom.Text = Var.GP_Nom;
                	textBox_GP_Prénom.Text = Var.GP_Prénom;
                	textBox_GP_Login.Text = Var.GP_Login;
                	textBox_GP_MDP.Text = Var.GP_MDP;
	            }
	        }
	    }
