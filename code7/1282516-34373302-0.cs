    public void Delete()
    {
        var pairToDelete = Convert.ToInt32(textBox1.Text);
            
        // Find what to remove.
        var lblToDelete = this.Controls.OfType<Label>()
                .FirstOrDefault(l => l.Tag.ToString() == pairToDelete.ToString());
        var txtToDelete = this.Controls.OfType<RichTextBox>()
                .FirstOrDefault(c => c.Tag.ToString() == pairToDelete.ToString());
            
        // Can be removed?
        if (lblToDelete != null)
        {
            // Remove.
            this.Controls.Remove(lblToDelete);
            lblToDelete.Dispose();
            // Lower tag number for labels with tag higher then the removed one.
            this.Controls.OfType<Label>()
                    .Where(l => Convert.ToInt32(l.Tag) > pairToDelete)
                    .ToList()
                    .ForEach(l => l.Tag = (Convert.ToInt32(l.Tag) - 1));
        }
        // Can be removed?
        if (txtToDelete != null)
        {
            // Remove.
            this.Controls.Remove(txtToDelete);
            txtToDelete.Dispose();
            // Lower tag number for rich textvbox with tag higher then the removed one.
            this.Controls.OfType<RichTextBox>()
                    .Where(r => Convert.ToInt32(r.Tag) > pairToDelete)
                    .ToList()
                    .ForEach(r => r.Tag = (Convert.ToInt32(r.Tag) - 1));
        }
    }
