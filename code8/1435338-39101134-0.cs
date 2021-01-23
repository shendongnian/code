            private void dataGridView13_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender; //get current datagridview
            string codearticle = "'" + CodeArticle0.Text + "'";
            string division = "'" + Division0.Text + "'";
            string colonne = grid.Columns[e.ColumnIndex].HeaderText; //get column headertext of current cell 
            string valeur = grid[e.ColumnIndex, e.RowIndex].Value.ToString(); //get new value of current cell
            string Ligne = grid[3, 0].Value.ToString(); 
            Controller.ControllerMenuPrincipal.updateQALigneFab(codearticle, division, colonne, valeur, Ligne); //calling stored procedure to update my table
        }
