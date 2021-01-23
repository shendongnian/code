        private void tabControl1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
            Point clientPoint = tabControl1.PointToClient(new Point(e.X, e.Y));
            for (int i = 0; i < tabControl1.TabCount; i++)
            {
                if (tabControl1.GetTabRect(i).Contains(clientPoint) && tabControl1.SelectedIndex != i)
                {
                    tabControl1.SelectedIndex = i;
                }
            }
        }
