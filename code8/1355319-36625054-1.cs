     myRichTextBox.OnTextChanged() {
        int number = 0;
        bool checkInt = Int32.TryParse(myRichTextBox.Text, out number); //this checks if the value is int and stores as true or false, it stores the integer value in variable "number"
        if ( checkInt =  true && number > 500  ) //check if value in textbox is integer
            {
                myRichTextBox.Text = number.ToString();
            }
        else 
        {
            DialogBox.Show("Please Enter Numbers Only");
            myRichTextBox.Text = "";
        }
    }
