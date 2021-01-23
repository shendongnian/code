        bool isDirty;
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            SetDirty(true);
        }
        private void SetDirty(bool dirty)
        {
            isDirty = dirty;
        }
        private void Submit()
        {
            if(isDirty)
            {
                // Save logic
            }
        }
