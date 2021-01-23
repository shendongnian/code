    using System.Windows.Input;
    ....
    private void OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
    {
        var isLeftControlUp = Keyboard.IsKeyDown(Key.LeftCtrl)
    }
