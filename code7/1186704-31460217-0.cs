        void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                List<string> filesToDrag = new List<string>();
                foreach (var item in FileList.SelectedItems)
                {
                    filesToDrag.Add(item.ToString().Trim());
                }
                if (filesToDrag.Count > 0)
                {
                    this.FileList.DoDragDrop(new DataObject(DataFormats.FileDrop,
                                         filesToDrag.ToArray()), DragDropEffects.Copy);
                }
                else
                {
                    MessageBox.Show("Select Files First!");
                }
            }
        }
