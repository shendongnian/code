    // View.xaml
    ...
    <Button x:Name="ExitButton" Clicked="CloseApp_OnClicked">
    
    // View.xaml.cs (code-behind)
    public void CloseApp_OnClicked(object sender, MouseEventArgs e)
    {
        this.Close();
    }
