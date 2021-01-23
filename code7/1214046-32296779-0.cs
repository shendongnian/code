    <TextBox x:Name="ThingyBox" IsEnabledChanged="ThingyBox_IsEnabledChanged"/>
    private void ThingyBox_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        ((TextBox)sender).Focus();
    }
