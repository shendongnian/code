        /// <summary>
        /// Gets or sets the Label which is displayed next to the field
        /// </summary>
        [Description("Username, split first and last names"), Category("Common Properties")]
        public String UserName
        {
            get { return (String)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }
        public static readonly DependencyProperty UserNameProperty = DependencyProperty.Register("UserName", typeof(String), typeof(UserProfile), UserNamePropertyChanged);
        private static void UserNamePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            UserProfile profile = sender as UserProfile;
                        
            TextBlock firstName = profile.GetTemplateChild("firstName") as TextBlock;
            TextBlock lastName = profile.GetTemplateChild("lastName") as TextBlock;
            if (firstName != null && lastName != null)
            {
                if (args.NewValue == null)
                {
                    firstName.Text = string.Empty;
                    lastName.Text = string.Empty;
                }
                else
                {
                    string newValue = args.NewValue.ToString();
                    if (string.IsNullOrWhiteSpace(newValue))
                    {
                        firstName.Text = string.Empty;
                        lastName.Text = string.Empty;
                    }
                    else
                    {
                        string[] splittedValues = newValue.Split(' ');
                        if (splittedValues.Length == 1)
                        {
                            firstName.Text = newValue;
                            lastName.Text = string.Empty;
                        }
                        else if (splittedValues.Length == 2)
                        {
                            firstName.Text = splittedValues[0];
                            lastName.Text = splittedValues[1];
                        }
                        else if (splittedValues.Length > 2)
                        {
                            firstName.Text = splittedValues[0];
                            lastName.Text = newValue.Substring(splittedValues[0].Length + 1);
                        }
                    }
                }
            }
        }
