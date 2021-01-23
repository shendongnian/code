        bool cancelIt = false;
        private void dataGridViewMsg_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            [...] // Here, treatment determines is the new cell value isValid or not
        
            if (cancelIt && !isValid)
            {
                MessageBox.Show("The value entered is incorrect.", "Modification aborted");
                e.Cancel = true;
                dataGridViewMsg.EndEdit();
                cancelIt = false;
            }
        }
        
        //CellBeginEdit event -> the user has edited the cell and the cancellation part 
        //can be executed without any problem
        private void dataGridViewMsg_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            cancelIt = true;
        }
