    <!--  View.xaml  -->
    <Window.Resources>
         <viewModel:MainViewModel x:Key="MyViewModel">
    </Window.Resources>
    ...
    <Button x:Name="ExitButton" Clicked="CloseApp_OnClicked">
    
    // View.xaml.cs (code-behind)
    public void CloseApp_OnClicked(object sender, MouseEventArgs e)
    {
        // Check if the ViewModel's data is saved before closing the app (state check)
        var theViewModel = this.Resources["MyViewModel"] as MainViewModel;
        if ( (theViewModel != null) && (theViewModel.DataIsSaved) )
            this.Close();
    }
