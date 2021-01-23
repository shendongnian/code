    private void canvas_MouseDown(object sender, MouseEventArgs e)
    {
       if (canvas.Image != null)
       {
           ChangeHistory.Add(canvas.Image);
       }
       ChangeHistoryIndex = ChangeHistory.Count - 1;
       MouseIsDown = true;
    }
