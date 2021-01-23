	    private void listBox_GP_Fichiers_SelectedIndexChanged(object sender, EventArgs e)
	    {
	        if (listBox_GP_Fichiers.SelectedItems.Count == 0)
	        	return;
            
            for(int x = 0; x < dataGridView_P.RowCount; x++)
            {	                
            	string s = "";
				string aux = "";
				s = dataGridView_P[1, x].Value.ToString() + " " + dataGridView_P[2, x].Value.ToString();
				aux = listBox_GP_Fichiers.SelectedItems[0].ToString();
				
				if (s.Equals(aux))
                {
                    Var.GP_Id = dataGridView_P[0, x].Value.ToString();
                    Var.GP_Access_Level = dataGridView_P[3, x].Value.ToString();
                    Var.GP_Color = dataGridView_P[4, x].Value.ToString();
                    textBox_GP_Nom.Text = Var.GP_Nom = dataGridView_P[1, x].Value.ToString();
                    textBox_GP_Prénom.Text = Var.GP_Prénom = dataGridView_P[2, x].Value.ToString();
                    textBox_GP_Login.Text = Var.GP_Login = dataGridView_P[5, x].Value.ToString();
                    textBox_GP_MDP.Text = Var.GP_MDP = dataGridView_P[6, x].Value.ToString();              
                }
            }
	    }
