    private void counter() {
        for (int i = 0; i < 10000; i++) {
            Thread.Sleep(1000); 
                // “There's never an advantage in replacing Thread.Sleep(1000); in Task.Delay(1000).Wait();”
                // http://stackoverflow.com/a/29357131/4267982
            Dispatcher.Invoke(() => { 
                textBox1.Text = i.ToString();
            });
        }
    }
