    public void ChangeBackground()
    {
        FormB b = new FormB();
        b.ShowDialog();
        this.BackgroundImage = b.SelectedImage;
    }
