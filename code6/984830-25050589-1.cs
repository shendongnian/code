    FlowLayoutPanel flowPanel = new FlowLayoutPanel();
            string m_pwd = "PWD";
            string m_senior = "Senior";
            string toBeColored = "Hi " + m_senior + " and " + m_pwd;
            string[] splitColored = toBeColored.Split(' ');
            foreach (string s in splitColored)
            {
                Label l = new Label();
                l.Text = s;
                if (s == m_pwd)
                {
                    l.ForeColor = Color.Red;
                }
                else if (s == m_senior)
                {
                    l.ForeColor = Color.Blue;
                }
                flowPanel.Controls.Add(l);
            }
            this.Controls.Add(flowPanel); //was missing from earlier example 
