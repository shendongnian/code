    private void btnLoadCustRemitt_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Dispatcher.BeginInvoke(new Action(() => 
            {
                CustomerRemittReportWin cusRemRep = new CustomerRemittReportWin();
                cusRemRep.Show();
            };
        }
        catch (Exception ex)
        { this.MyErrorMessage(ex);
    
        MessageBox.Show("This Part Executed");
        }
    }
