    private void ClearUsers()
        {
            List<Control> ctrls = new List<Control>();
            foreach (Control c in flw_users.Controls)
            {
                ctrls.Add(c);
            }
            flw_users.Controls.Clear();
            foreach (Control c in ctrls)
            {
                c.Dispose();
            }
        }
