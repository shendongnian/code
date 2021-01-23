            string gender = string.Empty;
            if (radioButton_Female.Checked)
            {
                gender = "Female";
            }else if (radioButton_Male.Checked)
            {   
                gender = "Male";
            }else
            {
                throw new Exception("Error msg");
            }
        
