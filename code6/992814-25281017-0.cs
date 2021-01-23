        public Form1()
        {
            InitializeComponent();
            this.CreatePictureRelatedControls();
        }
        private void CreatePictureRelatedControls()
        {
            Int32 xPictureControls = 50,
                yPictureControls = 50,
                xAssociatedControls = 200,
                yAssociatedControls = 50,
                yMargin = 10;
            Int32 controlWidth = 125,
                controlHeight = 20;
                
            Int32 controlCount = 3;
            var associatedControls = new Button[controlCount];
            for (int i = 0; i < associatedControls.Length; i++)
            {
                var associatedButton = new Button()
                {
                    Left = xAssociatedControls,
                    Top = yAssociatedControls + (i * (controlWidth + yMargin)),
                    Width = controlWidth,
                    Height = controlHeight,
                    Text = String.Format("associated control {0}", i),
                    Visible = false
                };
                // Event handler for associated button
                associatedButton.Click += (sender, eventArgs) =>
                    {
                        MessageBox.Show(((Control)sender).Text, "Associated control clicked");
                    };
                associatedControls[i] = associatedButton;
            }
            var pictureControls = new Button[controlCount];
            for (int i = 0; i < pictureControls.Length; i++)
            {
                var pictureButton = new Button()
                {
                    Left = xPictureControls,
                    Top = yPictureControls + (i * (controlWidth + yMargin)),
                    Width = controlWidth,
                    Height = controlHeight,
                    Text = String.Format("picture part button {0}", i),
                    // Use of tag property to associate the controls
                    Tag = associatedControls[i],
                    Visible = true
                };
                // Event hadler for picture button
                pictureButton.Click += (sender, eventArgs) =>
                    {
                        Control senderControl = (Control)sender;
                        Control associatedControl = (Control)senderControl.Tag;
                        associatedControl.Visible = !associatedControl.Visible;
                    };
                pictureControls[i] = pictureButton;
            }
            this.Controls.AddRange(associatedControls);
            this.Controls.AddRange(pictureControls);
        }
