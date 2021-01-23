	private async void QuestionNumber_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
        QuestionNumber.Foreground = new SolidColorBrush(Colors.Gray);
        await System.Threading.Tasks.Task.Delay(1000);
        QuestionNumber.Foreground = new SolidColorBrush(Colors.Yellow);
    }
