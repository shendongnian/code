        void MyButtonClicked(object sender, EventArgs e)
        {
            //First we need to convert our object to a button.
            Button ClickedButton = sender as Button;
            //And there we have our item.
            //We can change the text for example:
            ClickedButton.Text = "The world says: \"Hello!\"";
        }
