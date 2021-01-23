            private void Dgrd_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
            {
                SomeEntity item = (SomeEntity) Dgrd.CurrentItem; 
                if(item.Donate > 100)
                    viewModel.SyncColumnVisibility = Visibility.Collapsed;
                else
                    viewModel.SyncColumnVisibility = Visibility.Visible;    
            }
