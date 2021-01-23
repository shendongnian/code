    foreach (string file in tempfiles) {
        for (int i = 0; i < copylist .Length; i++) {
            if (Path.GetFileName(file) == Path.GetFileName(copylist [i])) {
                MessageBox.Show($"Removed: {file}\ninserted:{copylist [i])}";
                Filelist.RemoveAt(x);
                Filelist.Insert(x,copylist[i]);
                break; // << Added
            }
        }
        x++; // << Moved
    }
