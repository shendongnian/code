            private async void btnProntuario_Click(object sender, RoutedEventArgs e)
        {
            if ((App.Current as App).Telefone)
            {
                MessageDialog dialogo = new MessageDialog("My message!");
                await dialogo.ShowAsync();
            }
            else
            {
                frmPrincipal.Navigate(typeof(Prontuario));
            }
        }
