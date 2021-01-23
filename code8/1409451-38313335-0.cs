    protected override void OnMouseClick ( MouseEventArgs e )
    {
        Debug.WriteLine("Mouse click"); //works
    }
    
    private void panel1_MouseClick ( object sender, MouseEventArgs e )
    {
        OnMouseClick(e);
    }
