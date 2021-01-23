    private void BloodGroup_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
        if (SelectGroup.Visibility == System.Windows.Visibility.Collapsed)
            SelectGroup.Visibility = System.Windows.Visibility.Visible;
        else
            SelectGroup.Visibility = System.Windows.Visibility.Collapsed;
    }
