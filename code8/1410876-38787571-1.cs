        private void myListView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
            e.Handled = true;
            Debug.Print("DragOver reached\n");
        }
        private void myListView_DragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
            e.Handled = true;
            Debug.Print("DragOver reached\n");
        }
