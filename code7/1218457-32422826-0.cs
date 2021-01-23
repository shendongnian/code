    protected void onTextChanged(object sender, EventArgs e){
        try{
                int sum = 0;//your sum
                foreach (Control c in groupBox1.Controls)//iterate over each control insied groupbox
                {
                    if (c as TextBox != null)//if controller is a textbox instance
                    {
                        sum += Convert.ToInt32(c.Text);//you can use float long or double datatype according to your need
                    }
                }
                Label1.Text = sum.ToString();//sum of the integers in all text boxes
            }
            catch( Exception ex){
                 //your exception handling for num integer input goes here
            }
    }
