    string[] ResultTemp = Result.Split(new char[] { ';' });
    foreach (string a in ResultTemp) {
        if (a !="") {
            System.Windows.Forms.MessageBox.Show(a);
        }
    }
