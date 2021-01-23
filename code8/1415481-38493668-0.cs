    private void btn_submit_Click(object sender, EventArgs e)
    {
        string name = txt_name.Text;
        string email = txt_email.Text;
        string address = txt_address.Text;
        string course = txt_course.Text;
        string phone = txt_phone.Text;
        bool formIsValid = true;
        if (name.Length < 8)
        {
            txt_name.Text = "Invalid Name";
            txt_name.ForeColor = Color.Red;
            formIsValid = false;
        }
        else
        {
            txt_name.ForeColor = Color.Green;
        }
        if (email.Contains('@'))
        {
            if (email.Contains(".com") || email.Contains(".COM"))
            {
                txt_email.ForeColor = Color.Green;
            }
            else
            {
                txt_email.Text = "invalid Email";
                txt_email.ForeColor = Color.Red;
                formIsValid = false;
            }
        }
        else
        {
            txt_email.Text = "invalid Email";
            txt_email.ForeColor = Color.Red;
            formIsValid = false;
        }
        if (address.Length < 12)
        {
            txt_address.Text = "invalid Address";
            txt_address.ForeColor = Color.Red;
            formIsValid = false;
        }
        else
        {
            txt_address.ForeColor = Color.Green;
        }
       if (course.Contains("Games Design") || course.Contains("Electronics") || course.Contains("Mobile Communications") || course.Contains("GAMES DESIGN") || course.Contains("ELECTRONICS") || course.Contains("MOBILE COMMUNICATIONS"))
        {
            txt_course.ForeColor = Color.Green;
        }
        else
        {
            txt_course.Text = "invalid Course";
            txt_course.ForeColor = Color.Red;
            formIsValid = false;
        }
       if (phone.Length < 8)
        {
            txt_phone.Text = "invalid Phone Number";
            txt_phone.ForeColor = Color.Red;
            formIsValid = false;
        }
       else
        {
            txt_phone.ForeColor = Color.Green;
        }
 
        if (formIsValid)
        {
            //submit the form
        }
        else
        {
            MessageBox.Show("Your error message here");
        }
    }
