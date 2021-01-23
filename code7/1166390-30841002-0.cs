     List<CheckBox> lstChckBox;
        protected void Page_Load(object sender, EventArgs e)
        {
            // you can create controls programaticaly or html page, doesnt important
            //only you should know controls ID and all controls share same checked event
            CheckBox chc1 = new CheckBox();
            chc1.CheckedChanged += new EventHandler(chck_CheckedChanged);
            CheckBox chc2 = new CheckBox();
            chc2.CheckedChanged += new EventHandler(chck_CheckedChanged);
            CheckBox chc3 = new CheckBox();
            chc3.CheckedChanged += new EventHandler(chck_CheckedChanged);
            // Now, you can create a List so event is fired, you can catch which controls checked or not 
            lstChckBox = new List<CheckBox>();
            lstChckBox.Add(chc1);
            lstChckBox.Add(chc2);
            lstChckBox.Add(chc3);
        }
        void chck_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (sender as CheckBox);
            foreach (CheckBox item in lstChckBox)
            {
                if (item != checkBox)
                {
                    item.Checked = !checkBox.Checked;
                }
            }
        }
