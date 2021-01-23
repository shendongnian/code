        private void setLabelText(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                label.Invoke((System.Action)(() => setLabelText(label, text)));
            }
            else
            {
                label.Text = text;
            }
        }
