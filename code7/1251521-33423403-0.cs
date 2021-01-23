            if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                for (int i = 0; i < tabControl.TabCount; i++)
                {
                    if (tabControl.GetTabRect(i).Contains(e.Location))
                    {
                        tabPaControl.TabPages[i].Dispose();
                    }
                }
            }
        }`
