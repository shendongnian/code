    private void Canvas_Paint(object sender, PaintEventArgs e)
    {
        Start(canvas);
    }
    public void Start(Control uiControl)
    {
        AsyncOperation asyncOperation = AsyncOperationManager.CreateOperation(null);
        asyncOperation.Post(Render, uiControl);
    }
    private void Render(object g)
    {
        ((Control)g).CreateGraphics().DrawRectangle(Pens.Red, 50, 50, 50, 50);
    } 
