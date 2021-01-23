    var SkypeClient = new SKYPE4COMLib.Skype();
    foreach (SKYPE4COMLib.User User in SkypeClient.Friends)
    {
        if(User.Handle.ToLower() == TextBoxName.Text.ToLower()) //Using ToLower() for case-insensitive checking.
        {
            TextBoxFullName.Text = User.FullName; //Contact's full name.
            TextBoxMood.Text = User.Mood; //Contact's mood text.
            TextBoxCity.Text = User.City; //Contact's city.
            //...and so on.
            break; //Terminate the loop.
        }
    }
