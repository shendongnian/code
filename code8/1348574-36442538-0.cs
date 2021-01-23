            private async void btnFinanceiro_Click(object sender, RoutedEventArgs e)
        {
            if (ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                MessageDialog dialogo = new MessageDialog("My message!");
                await dialogo.ShowAsync();
            }
            else
            {
                frmPrincipal.Navigate(typeof(Financeiro));
            }
        }
