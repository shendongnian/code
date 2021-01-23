    private void button12_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Pick a position after clicking OK", "OK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
        {
            // user clicked ok
            Point coordinates = Cursor.Position;
            MessageBox.Show("Coordinates are: " + coordinates);
        }
    }
