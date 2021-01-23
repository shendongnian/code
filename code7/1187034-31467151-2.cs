        Dictionary<string, int> dicIndexSelected = new Dictionary<string, int>();
        public System.Windows.Forms.ComboBox AddNewSEPComboBox()
        {
            System.Windows.Forms.ComboBox SEPcbox = new System.Windows.Forms.ComboBox();
            SEPcbox.Top = A * 28;
            SEPcbox.Left = 250;
            SEPcbox.Location = new Point(20, A * 30);
            string[] SEPSTAT = new string[] { "current (12.1.4013.4013), no changes made.", "not installed, no changes made.", "not installed, latest version (12.1.4013.4013) installed.", "outdated, updated to the latest version (12.1.4013.4013).", "outdated, no changes made." };
            SEPcbox.Items.AddRange(SEPSTAT);
            SEPcbox.Name = "SEPcbox" + A;
            A++;
            this.Controls.Add(SEPcbox);
            dicIndexSelected.Add(SEPcbox.Name, -1);
            SEPcbox.SelectedIndexChanged += new EventHandler(SEPcbox_SelectedIndexChanged);
            return SEPcbox;
        }
        void SEPcbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dicIndexSelected[((System.Windows.Forms.ComboBox)sender).Name] = ((System.Windows.Forms.ComboBox)sender).SelectedIndex;
        }
