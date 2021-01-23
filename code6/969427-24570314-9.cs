    public void Do(MainWindow window)
    {
        Task.Factory.StartNew(() => {
            window.UpdateStatus("test");
            for (int i = 1; i < 1000000; i++)
                i += i;
            Thread.sleep(100);
            window.UpdateStatus(i.tostring());
        });
    }
