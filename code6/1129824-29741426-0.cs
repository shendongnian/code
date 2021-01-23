    int CallIndex = 0; // this is on the form level
        private void button1_Click(object sender, EventArgs e)
        {
            createPictureBox(3);
            CallIndex += 1;
        }
        private void createPictureBox(int size)
        {
        // this has the exact same code as your method (copy-paste into my visual studio), 
        // except this change: 
        // ParameterLabel[i].Text = "Test Text";
        ParameterLabel[i].Text = string.Format("Test {0}", CallIndex); // instead of the row above
        }
