        public void NameCheck()
        {
            string value = "Type here";
            if (globalVariables.InputBox("Name", "Please enter name", ref value) == DialogResult.OK)
            {
                name = value;
                if (name.All(char.IsLetter))
                {
                    lblName.Text = value;
                }
                else
                {
                    NameCheck();
                }
            }
        }
        private void gameForm_Load(object sender, EventArgs e)
        {
            NameCheck();
        }
