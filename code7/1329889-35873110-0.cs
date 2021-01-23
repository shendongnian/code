    <Button Click="Button_Click" Text="Click Me"/>
...
    async void Button_Click(object sender, EventArgs eventArgs) {
        Service1Client dataCommunicator = new Service1Client();
        try {
            bool result =
                await Task.Factory.FromAsync<string, Monument, string, IMEI, bool>(
                    dataCommunicator.BeginGiveFeedback,
                    dataCommunicator.EndGiveFeedback,
                    editPhoneF.Text,
                    monuments[pickerMonument.SelectedIndex],
                    editRemarks.Text,
                    imei);
            if (e.Result) {
                await DisplayAlert("Success", "Thank you for your valuable comments", "Ok");
            } else {
                await DisplayAlert("Internal server error", "Please try again later.", "Ok");
            }
        } catch (Exception ex) {
            await DisplayAlert("Server communication error", "Please try again later. ERROR: " + ex.GetType().Name, "Ok");
        }
    }
