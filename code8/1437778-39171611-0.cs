        public void log(string txt)
        {
            logtext.Append(Environment.NewLine + txt);
            txtLog.Invoke(new Action(delegate { txtLog.Text = logtext.ToString(); }));
        }
