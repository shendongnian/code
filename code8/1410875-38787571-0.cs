        private void myListView_DragEnter(object sender, DragEventArgs e)
        {
            myListView.Focus();
            e.Effects = DragDropEffects.Copy;
            Debug.Print("DragOver reached");
        }
        private void myListView_DragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
            Debug.Print("DragOver reached");
        }
