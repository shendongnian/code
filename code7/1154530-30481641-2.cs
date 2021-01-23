    private void GetName_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
       var element = (FrameworkElement)sender;
       StaffData data = (StaffData)element.DataContext;
       MessageBox.Show(data.Name);
    }
