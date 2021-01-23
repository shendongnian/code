        private void button1_Click(object sender, EventArgs e)
        {
            postgresConnection _con = new postgresConnection();
            group va = (group)comboGrupper.SelectedItem;
            int index = va.gruppid;
            foreach (person item in checkedListBox1.CheckedItems)
	            {
                    _con.AddPeopleAttendance(item.personid, index);
	            }
        }
