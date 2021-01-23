        private void MyMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                Control source = (Control)sender;
                source.DoDragDrop(new MyWrapper(source), DragDropEffects.Move);
            }
        }
