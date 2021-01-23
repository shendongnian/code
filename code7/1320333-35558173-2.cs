    private void control_MouseDown(object sender, MouseEventArgs e)
    {
        var control = sender as Control;
        this.DoDragDrop(control.Name, DragDropEffects.Move);
    }
    private void panel_DragEnter(object sender, DragEventArgs e)
    {
        if (!e.Data.GetDataPresent(typeof(string)))
            return;
        var name = e.Data.GetData(typeof(string)) as string;
        var control = this.Controls.Find(name, true).FirstOrDefault();
        if (control != null)
        {
            e.Effect = DragDropEffects.Move;
        }
    }
    private void panel_DragDrop(object sender, DragEventArgs e)
    {
        if (!e.Data.GetDataPresent(typeof(string)))
            return;
        var name = e.Data.GetData(typeof(string)) as string;
        var control = this.Controls.Find(name, true).FirstOrDefault();
        if (control != null)
        {
            control.Parent.Controls.Remove(control);
            var panel = sender as FlowLayoutPanel;
            ((FlowLayoutPanel)sender).Controls.Add(control);
        }
    }
