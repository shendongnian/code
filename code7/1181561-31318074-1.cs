    public virtual void Dispose() {
        if (IsOpen()) {
            Close();
        }
    }
