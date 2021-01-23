    private async void OnButton1_clicked(object sender, ...)
    {
        Task task1 = StartTask1(...);
        Task task2 = StartTask2(...);
        // while the tasks are being performed do other things,
        // after a while wait until all tasks are finished
        await Task.WhenAll(new Task[] {task1, task2};
        MessageBox.Show(...)
     }
