    <!--  View.xaml  -->
    <Window.Resources>
         <viewModel:MainViewModel x:Key="MyViewModel">
    </Window.Resources>
    ...
    <Button x:Name="ExitButton" Clicked="CloseApp_OnClicked">
    
    // View.xaml.cs (code-behind)
    public void CloseApp_OnClicked(object sender, MouseEventArgs e)
    {
        var theViewModel = this.Resources["MyViewModel"] as ViewModel;
        if ( (theViewModel != null) && (theViewModel.DataIsSaved) )
            this.Close();
    }
