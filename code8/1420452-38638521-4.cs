    private void btnAddDriver_Click(object sender, RoutedEventArgs e)
        {
            if (cmbOccupation.SelectedItem.ToString() == Occumpation.Chauffeur.ToString())
            {
                policy = (policy + policy*Chauffeur);
                txtPolicy.Text =  policy.ToString();
            }
            else if(cmbOccupation.SelectedItem.ToString()== Occumpation.Accountant.ToString())
            {
                policy = (policy - policy*Accountant);
                txtPolicy.Text = policy.ToString();
            }
            DateTime birthDate = Convert.ToDateTime(dpkDOB.SelectedDate);
            if (birthDate.Age().Years() > 21 && birthDate.Age().Years() < 26)
            {
                policy = (policy + policy*age2125);
                txtPolicy.Text = policy.ToString();
            }
            else if (birthDate.Age().Years() > 26 && birthDate.Age().Years() < 76)
            {
                policy = (policy - policy*age2675);
                txtPolicy.Text = policy.ToString();
            }
        }
