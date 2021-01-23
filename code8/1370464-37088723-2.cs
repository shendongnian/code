    using (var db = new MonitoringSystemContext())
                {
                    dynamic selectedService = ItServiceDataGrid.SelectedItem;            
                    try
                    {
                        int ID = selectedService.Service_ID;
                        var deletedService = db.IT_Service.FirstOrDefault(s=> s.Service_ID == ID);
                        if(deletedService != null)
                        {
                        db.IT_Service.Remove(deletedService);
                        db.SaveChanges();
                        MessageBox.Show("Successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                       }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    finally
                    {
                        UpdateDataGrids();
                    }                
                }
