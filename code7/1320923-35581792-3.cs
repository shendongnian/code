    private void control_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
            DoDragDrop((sender as Control), DragDropEffects.Move); 
    }
