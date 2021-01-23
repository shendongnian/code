       private void MyControl_DragOver(object sender, DragEventArgs e) {
            e.Effects = DragDropEffects.None;
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                string[] paths = e.Data.GetData(DataFormats.FileDrop) as string[];
                if(paths.Lenght > 0 && File.Exists(paths[0])) { // <- example, you must handle it in your way
                    e.Effects = DragDropEffects.Copy | DragDropEffects.Move;
                }
            }
        }
