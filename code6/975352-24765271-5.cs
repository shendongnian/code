        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (canvas.Image != null)
                ChangeHistory.Push(canvas.Image);
            MouseIsDown = true;
        }
        private void Undo_Click(object sender, EventArgs e)
        {
            if (ChangeHistory.Count > 0)
                canvas.Image = ChangeHistory.Pop();
            else
                canvas.Image = null;
        }
