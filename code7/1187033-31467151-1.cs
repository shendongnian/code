        List<System.Windows.Forms.ComboBox> lstComboBoxAdded = new List<System.Windows.Forms.ComboBox>();
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
            lstComboBoxAdded.Add(SEPcbox);
            return SEPcbox;
        }
