        bool isDirty;
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            // Possible validation here
            SetDirty(true);
        }
        private void SetDirty(bool dirty)
        {
            // Possible global validation here
            isDirty = dirty;
        }
        private void Submit()
        {
            if(isDirty)
            {
                // Save logic
            }
        }
