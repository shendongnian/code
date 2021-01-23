      private string imageName = "pic.jpg";
      private void Button_Click(object sender, RoutedEventArgs e)
      {
        imageName = "pic.jpg";
        Windows.ApplicationModel.DataTransfer.DataTransferManager.ShowShareUI();
      }
      private void Button1_Click(object sender, RoutedEventArgs e)
      {
        imageName = "pic1.jpg";
        Windows.ApplicationModel.DataTransfer.DataTransferManager.ShowShareUI();
      }
