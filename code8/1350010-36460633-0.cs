	private void btnSum_Click(object sender, RoutedEventArgs e)
	{
		int n1;
		int n2;
		if(!int.TryParse(txtNum1.Text, out n1) || !int.TryParse(txtNum2.Text, out n2))
		{
			MessageBox.Show("Enter valid numbers");
		}
		else 
		{   
		   MessageBox.Show("The sum is: " + (n1 + n2));   
		}
	}
