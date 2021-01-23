    private void cmdSubmit_Click(object sender, EventArgs e)
    {
        var name = txtName.Text;
        int age;
		if(Int32.TryParse("txtAge.Text, out age))
		{
            MessageBox.Show($"Your name is {name} and You're {age} years old.");
		}
		else
		{
			MessageBox.Show("Enter valid age");			
		}
        
    }
