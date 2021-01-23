        private readonly Queue<int> _queue = new Queue<int>();
        private readonly object _locker = new object();
        public void Thread1()
        {
            List<int> values = new List<int>();
            int lastInput;
            StringBuilder sb = new StringBuilder();
            while (values.Count < 5)
            {
                lock (this._locker)
                {
                    // wait until there is something in the queue
                    if (this._queue.Count == 0)
                    {
                        Monitor.Wait(this._locker);
                    }
                    // get the item from the queue
                    _queue.Dequeue(out lastInput);
                    // add the item to the list
                    values.Add(lastInput);
                }
            }
            for (int i = 0; i < values.Count; i++)
            {
                sb.Append(String.Format("{0}\n", values[i]));
            }
            MessageBox.Show(sb.ToString());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Thread th1 = new Thread(Thread1);
            th1.Start();
            for (int i = 0; i < 8; i++)
            {
                lock (this._locker)
                {
                    // put something in the queue
                    _queue.Enqueue(i);
                    // notify that there is something in the queue
                    Monitor.Pulse(this._locker);
                }
            }
        }
