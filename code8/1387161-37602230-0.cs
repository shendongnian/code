        private void ChangeStatus()
        {
            //loop through the RichtextBoxes
            foreach (RichTextBox rtb in this.Controls.OfType<RichTextBox>())
            {
                Color c = Color.Green; //default to good value
                //only handle the status Out Control
                if (rtb.Name.StartsWith("StatusOut"))
                {   ///check the value and set the color if false
                    if (rtb.Text == "false")
                        c = Color.Red;
                    //update the controls
                    rtb.BackColor = c;
                    //string controlNum = rtb.Name.Replace("StatusOut", ""); //If it is not 3 just use replace since we know we are on the StatusOut control
                    string controlNum = rtb.Name.Substring(rtb.Name.Length - 3);
                    ((RichTextBox)Controls["TripStateOut" + controlNum]).BackColor = c;
                    ((RichTextBox)Controls["VoltageOut" + controlNum]).Text = VoltageReading;
                    ((RichTextBox)Controls["CurrentOut" + controlNum]).Text = CurrentReading;
                }
            }            
        }
