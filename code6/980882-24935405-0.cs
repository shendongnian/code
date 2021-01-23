    /// Track number of request you will post to DB. Because it is a bad idea to create many concurrent connections and there is limit in your connection pool.
    static const ulong THRESHOLD= 5; // Put your number here.
    object syncObjetc = new object();    // Sync all reads/writes to your counter.
    volatile ulong counter = 0;
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if (textBox1.Text.Length <= 3)
        {
            _ishouldnteventrytoupdate = true;
            return;
        }
        _ishouldnteventrytoupdate = false;
        _updated = false;
        lock(syncObjetc){
            if (++counter >= THRESHOLD){
                  textBox1.Enabled = false;
            }
        }
        ThreadPool.QueueUserWorkItem(new WaitCallback(backgroundWorker1_DoWork), textBox1.Text);
    }
