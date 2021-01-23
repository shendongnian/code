        void radGanttView1_ContextMenuOpening(object sender, GanttViewContextMenuOpeningEventArgs e)
        {
            GanttViewDefaultContextMenu ganttMenu = ((GanttViewDefaultContextMenu)e.Menu);
            ganttMenu.ShowProgress = false;
            RadMenuItem progressItem = new RadMenuItem("Progress");
            e.Menu.Items.Add(progressItem);
            for (decimal i = 0; i <= 100; i += ganttMenu.ProgressStep)
            {
                GanttViewMenuItem menuItem = new GanttViewMenuItem(i.ToString(), string.Format("{0:P0}", i / 100));
                progressItem.Items.Add(menuItem);
                menuItem.IsChecked = e.Item.Progress == i;
                menuItem.Click += progressMenuItem_Click;
                menuItem.Enabled = i > e.Item.Progress;
            }
        }
        private void progressMenuItem_Click(object sender, EventArgs e)
        {
            GanttViewMenuItem item = (GanttViewMenuItem)sender;
            radGanttView1.GanttViewElement.SelectedItem.Progress = int.Parse(item.Command);
        }
