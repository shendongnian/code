        public PasswordInputBox(bool isForImage)
        {
            this.InitializeComponent();
            if (isForImage)
                //initialize actions for that part of the EmbedTypePanel;
            else
                EmbedTypePanel.Visibility = Visibility.Collapsed;
        }
