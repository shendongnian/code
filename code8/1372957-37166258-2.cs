    public void MyEven(object sender, EventArgs e)
            {
                CheckBox chek = (CheckBox)sender;
                MessageBox.Show("Check is pressed " + chek.Text);
    
            }
