    private void rentSaveButton_Click(object sender, RoutedEventArgs e)
    {
        using (StreamWriter sw = new StreamWriter(@"D:\deviceLib.txt", true))
        {
            var currentUser = _list.Where(u => u.Id == int.Parse(userIDTextBox.Text)).FirstOrDefault();
    
            var currentDevice = _list2.Where(i => i.deviceId == int.Parse(deviceIDTextBox.Text)).FirstOrDefault();
            if (currentDevice != null &&  currentUser != null)
            {
                currentDevice.Availability = false;
                currentDevice.rentId = currentUser.Id;
                currentDevice.rentName = currentUser.Name;
                currentDevice.rentSurname = currentUser.Surname;
                dataGridDeviceList.Items.Refresh();
                
                //  Call write method
                WriteDeviceStateToStream(sw, currentDevice);
                //  The user's going to get real tired of this messagebox real fast. 
                MessageBox.Show("Rent done. Thanks!");
                tabControl.SelectedItem = mainTab;
            }
            else
            {
                MessageBox.Show("We don't have such device. Sorry :( ");
                userIDTextBox.Clear();
                deviceIDTextBox.Clear();
            }
        }
    }
