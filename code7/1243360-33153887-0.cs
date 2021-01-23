        void renderSubPanels()
        {
            //panel.SuspendLayout();
            bool verticalScrollVisible = listOfPanels.Count * 100 > panel.ClientSize.Height;
            foreach (Panel p in listOfPanels)
            {
                if (verticalScrollVisible)
                {
                    p.Width = panel.Width - System.Windows.Forms.SystemInformation.VerticalScrollBarWidth - 2;
                }
                else
                {
                    p.Width = panel.Width - 2;
                }
                p.Top = (listOfPanels.IndexOf(p) * 100) - Math.Abs(this.AutoScrollPosition.Y);
            }
            //panel.ResumeLayout();
            panel.PerformLayout();
        }
