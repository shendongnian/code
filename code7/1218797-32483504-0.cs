    private void OnChecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)e.OriginalSource;
            DataGridRow dataGridRow = VisualTreeHelpers.FindAncestor<DataGridRow>(checkBox);
            DataRowView produit = (DataRowView)dataGridRow.Item;
            if (produit[3].Equals(""))
            {
                MessageBox.Show(
                    "Vous ne pouvez pas ajouter cette appellation car elle n'était pas créée l'année dernière. Veuillez la créer manuellement.", "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                
            }
            e.Handled = true;
        }
