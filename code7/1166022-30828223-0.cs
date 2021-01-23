    private void read_Delimited_File(string fileName, ref List<string> array1, ref List<string> array2)
            {
                StreamReader fileSR = new StreamReader(fileName);
                char[] delimiters = { ',' };
                string line = "";
                while ((line = fileSR.ReadLine()) != null)
                {
                    string[] tempArray = line.Trim().Split(delimiters);
                    array1.Add(tempArray[0]);
                    array2.Add(tempArray[1]);
                }
                fileSR.Close();
            }
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                Keyboard.Focus(phoneTextBox);
                List<string> cNames = new List<string>();
                List<string> cPhoneNumbers = new List<string>();
                read_Delimited_File(cFileName, ref cNames, ref cPhoneNumbers);
                for (int i = 0; i < array1.Length; i++)
                {
                    nameComboBox.Items.Add(array1[i]);
                }
                for (int i = 0; i < array2.Length; i++)
                {
                    phoneNumberComboBox.Items.Add(array1[i]);
                }
            }​
