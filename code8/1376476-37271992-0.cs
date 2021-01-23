        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataClasses1DataContext dbContext = new DataClasses1DataContext();
            List<string> selectedItems = (from object o in listBox1.SelectedItems select listBox1.GetItemText(o)).ToList();
            listBox2.DataSource = dbContext.Sessions
                .Where(pID => listBox1.SelectedItems.OfType<Session>().Select(x => x.PatientID).Contains(pID.PatientID));
            listBox2.DisplayMember = "Start";
            listBox2.ValueMember = "SessionID";
        }
