        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);
            {
                if (Path.GetExtension(file[0]) == ".url")
                {
                    //Do Stuff Here
                    //
                }
            }
        }
        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (Path.GetExtension(file[0]) == ".url")
            {
                e.Effect = DragDropEffects.Link;
                //Do Stuff Here
            }
        }
