    private async void dg_ItemClick(object sender, Windows.UI.Xaml.Controls.ItemClickEventArgs e)
    {
            Biz.Customer cust = e.ClickedItem as Biz.Customer;
            var messageDialog2 = new MessageDialog(cust.Code, cust.Company);
            await messageDialog2.ShowAsync();
    }
