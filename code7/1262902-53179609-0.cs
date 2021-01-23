        string mostRecentText = "";
        async void entry_textChanged(object sender, EventArgs e)
        {
            //get the entered text
            string enteredText = (sender as Entry).Text;
            //set the instance variable for entered text
            mostRecentText = enteredText;
            //wait 1 second in case they keep typing
            await Task.Delay(1000);
            //if they didn't keep typing
            if (enteredText == mostRecentText)
            {
                //do what you were going to do
                doSomething(mostRecentText);
            }
        }
