        private void CheckTodayLoad()
        {
            DateTime today;
            today = Convert.ToDateTime(DateTime.Today); 
            CycleCountRepository _rep = new CycleCountRepository();
            if (_rep.CheckTodayLoaded(today))
            {
                todayToolStripMenuItem.Image = Properties.Resources.checkmark;
                todayToolStripMenuItem.Text = "Today " + "[" + today.ToShortDateString() + "]" + " : Loaded";
                todayToolStripMenuItem.Click -= todayToolStripMenuItem_Click;
            }
            else
            {
                todayToolStripMenuItem.Image = SystemIcons.Warning.ToBitmap();
                todayToolStripMenuItem.Text = "Today " + "[" + today.ToShortDateString() + "]" + " : Not Loaded";
                todayToolStripMenuItem.Click -= todayToolStripMenuItem_Click; // Just to make sure it is not registered twice. Previously this line wasnt there
                todayToolStripMenuItem.Click += todayToolStripMenuItem_Click;
            }
        }
