    public bool FullControl {
        get {
            return btnNew.Enabled;
        }
        set {
            btnNew.Enabled = value;
            btnDelete.Enabled = value;
        }
    }
