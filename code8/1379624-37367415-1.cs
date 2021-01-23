    async void Test()
    {
        using (var player = new System.Media.SoundPlayer(@"C:\Windows\Media\Alarm01.wav"))
        {
            await Task.Run(() => { player.Load(); player.PlaySync(); });
            MessageBox.Show("Finished. Now you can run your code");
        }
    }
