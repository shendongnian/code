    var tasks = new List<Task>();
    for (int i = 0; i < 100000; i++)
    {
        var task = Task.Run(() =>
        {
            BitmapSource temp = null;
            temp = BitmapSource.Create(
                1,
                1,
                96,
                96,
                PixelFormats.Bgr24,
                null,
                new byte[3],
                3);
            temp.Freeze();
        });
        tasks.Add(task);
    }
    Task.WaitAll(tasks.ToArray());
