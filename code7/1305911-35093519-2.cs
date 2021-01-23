        protected void SubmitButton_OnClick(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                SaveFormSubmissionToDatabase();
                MyTextBox.Text = "";
            }
        }
