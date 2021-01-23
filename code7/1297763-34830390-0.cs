        string serializedButtonsPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\DynamicButtons.csv";
        private void button1_Click(object sender, EventArgs e)
        {
            // Create a Button object 
            Button dynamicButton = new Button();
            // Set Button properties
            dynamicButton.Height = 40;
            dynamicButton.Width = 300;
            dynamicButton.BackColor = Color.Red;
            dynamicButton.ForeColor = Color.Blue;
            dynamicButton.Location = new Point(20, 150);
            dynamicButton.Text = "I am Dynamic Button";
            dynamicButton.Name = "DynamicButton";
            dynamicButton.Font = new Font("Georgia", 16);
            //Naburi: Store function pointer before adding it to the event
            Action<object,EventArgs> dynamicButtonOnClick = dynamicButton_Click;
            dynamicButton.Click += new EventHandler(dynamicButtonOnClick);
            Controls.Add(dynamicButton);
            
            //Naburi: Serialize button (in strings)
            var membersData = new List<string>();
            membersData.Add(dynamicButton.Height.ToString());
            membersData.Add(dynamicButton.Width.ToString());
            membersData.Add(dynamicButton.BackColor.Name.ToString());
            membersData.Add(dynamicButton.ForeColor.Name.ToString());
            membersData.Add(dynamicButton.Location.X.ToString());
            membersData.Add(dynamicButton.Location.Y.ToString());
            membersData.Add(dynamicButton.Text);
            membersData.Add(dynamicButton.Name);
            membersData.Add(dynamicButton.Font.OriginalFontName);
            membersData.Add(dynamicButton.Font.Size.ToString());
            membersData.Add(dynamicButtonOnClick.Method.Name);
            //Naburi: Store data to csv TODO: improve format!!
            File.AppendAllText(serializedButtonsPath, string.Join(";", membersData));
        }
        private void button2_Click(object sender, EventArgs e)
        {//Naburi: load buttons
            var serializedButtons = File.ReadAllLines(serializedButtonsPath);
            foreach (var button in serializedButtons)
            {
                var membersData=button.Split(';');
                // Create a Button object 
                Button dynamicButton = new Button();
                // Set Button properties
                var i=0;
                dynamicButton.Height = int.Parse(membersData[i++]);
                dynamicButton.Width = int.Parse(membersData[i++]);
                dynamicButton.BackColor = Color.FromName(membersData[i++]);
                dynamicButton.ForeColor = Color.FromName(membersData[i++]);
                dynamicButton.Location = new Point(int.Parse(membersData[i++]), int.Parse(membersData[i++]));
                dynamicButton.Text = membersData[i++];
                dynamicButton.Name = membersData[i++];
                dynamicButton.Font = new Font(membersData[i++], float.Parse(membersData[i++]));
                //Store method name to make it independent of the index (i)
                var eventMethodName = membersData[i++];
                //Set the event by method name using reflection, the binding flags allow to access the private method
                dynamicButton.Click += (_sender, _e) => 
                        GetType().GetMethod(eventMethodName, BindingFlags.NonPublic|BindingFlags.Instance).Invoke(this, new[] { _sender, _e }
                    );
                Controls.Add(dynamicButton);
            }
        }
