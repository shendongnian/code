       private delegate void delegateAssignText();
        public void AssignText()
        {
            if (this.InvokeRequired)
            {
                Invoke(new delegateAssignText(AssignText));
                return;
            }
            for (int i = 0; i < 6; i++)
            {
                arrLabel[i].Text = values[0].ToString();
            }
        }
