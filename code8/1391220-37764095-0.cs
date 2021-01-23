    private void Window_Loaded_1(object sender, RoutedEventArgs e)
    {
        //read file on start
        int counter = 0;
        string line;
        StreamReader custSR = new StreamReader(cFileName);
        line = custSR.ReadLine();
    
        while (custSR.Peek() != -1)
        {
            Array.Resize(ref cPhone, cPhone.Length + 1);
            cPhone[cPhone.Length - 1] = line;
            counter++;
            line = custSR.ReadLine();
            Array.Resize(ref cName, cName.Length + 1);
            cName[cName.Length - 1] = line;
            counter++;
    
            line = custSR.ReadLine();
    
            phoneComboBox.Items.Add(cPhone[cPhone.Length - 1]);
        }
        custSR.Close();
    
         //focus when program starts
         phoneComboBox.Focus();
    }
