     private void DGVPurchase_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {
            if (e.Column is GridViewMultiComboBoxColumn)
            {
                RadMultiColumnComboBoxElement editor = e.ActiveEditor as RadMultiColumnComboBoxElement;
                editor.Columns["ShortName"].BestFit(); //Auto Widht
                editor.Columns["ID"].IsVisible = false; // Visiblity
                editor.Columns["Price"].Width = 120; //custom width
            }
        }
