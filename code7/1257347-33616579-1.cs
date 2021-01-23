        private bool ValidateIntInputFields()
        {
            if(string.IsNullOrEmpty(txtAge.Text))
                 return true;
            bool isValid = false;
            int resultAge; 
            if(int.TryParse(txtAge.Text, out resultAge))
            {
                isValid = true;
            }
            return isValid;
        }
