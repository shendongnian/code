        /// <summary>
        /// Gets or sets the Label which is displayed next to the field
        /// </summary>
        [Description("Username, split first and last names"), Category("Common Properties")]
        public String UserName
        {
            get { return (String)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }
        public static readonly DependencyProperty UserNameProperty = DependencyProperty.Register("UserName", typeof(String), typeof(UserProfile), new PropertyMetadata("Firstname Lastname",UserNamePropertyChanged));
        private static void UserNamePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            UserProfile profile = sender as UserProfile;
            profile.RefreshFirstAndLastName();            
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.RefreshFirstAndLastName();
        }
        private void RefreshFirstAndLastName()
        {
            TextBlock firstName = this.GetTemplateChild("firstName") as TextBlock;
            TextBlock lastName = this.GetTemplateChild("lastName") as TextBlock;
            if (firstName != null && lastName != null)
            {
                if (string.IsNullOrWhiteSpace(this.UserName))
                {
                    firstName.Text = string.Empty;
                    lastName.Text = string.Empty;
                }
                else
                {
                    string[] splittedValues = this.UserName.Split(' ');
                    if (splittedValues.Length == 1)
                    {
                        firstName.Text = this.UserName;
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
                        lastName.Text = this.UserName.Substring(splittedValues[0].Length + 1);
                    }
                }
            }
        }
