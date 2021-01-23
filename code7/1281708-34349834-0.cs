            ListViewItem listview;
            if(_schedule.MondayFrom != "")
            {
                checkBoxMon.Checked = true;
                listview = listViewEditSchedule.Items.Add("Monday");
                listview.SubItems.Add(_schedule.MondayFrom);
                listview.SubItems.Add(_schedule.MondayTo);
            }
