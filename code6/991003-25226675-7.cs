    ...
    <Button x:Name="ExitButton" Clicked="CloseApp_OnClicked">
    
    code-behind:
    public void CloseApp_OnClicked(object sender, MouseEventArgs e)
    {
        this.Close();
    }
