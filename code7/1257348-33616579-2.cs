        private void ClickSaveNewUser(object sender, EventArgs e)
        {
            if (ValidateStringInputFields() && ValidateIntInputFields())
            {
                int? convertAge = null;
				
				if( !string.IsNullOrEmpty(txtAge.Text) )
					convertAge = int.Parse(txtAge.Text);
					
                if(NullableTypeDB.AddNewEmployee(txtFname.Text, txtLname.Text, comBoxMaritalStatus.SelectedIndex, convertAge) == 1)
                {
                    MessageBox.Show("A New Employee Record has been Successfully Added");
                }
            }
        }
