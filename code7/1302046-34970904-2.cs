        private void mfiDeletePic_Loaded(object sender, RoutedEventArgs e)
        {
            var m = (MenuFlyoutItem)sender;
            if (m != null)
            {
                m.Command = Vm.DeleteImageCommand;
                //Vm is the ViewModel instance...
            }
        }
