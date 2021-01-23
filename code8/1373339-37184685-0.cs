    async private void StoresList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var item = (sender as ListView).SelectedItem as Models.StoresLM;
                if(item!=null)
                {
                    Properties.Settings.Default.StoreId = item.id;
                    Properties.Settings.Default.Save();
                    await _DashVM.GetDashboardData();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
            }
        }
