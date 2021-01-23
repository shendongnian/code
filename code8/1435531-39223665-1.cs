            Timer t = new Timer(callback =>
            {
                foreach (var msg in _queue.GetConsumingEnumerable())
                {
                    File.AppendAllText(msg.Filepath, msg.Text);
                }
            }, null, 0, (long)TimeSpan.FromSeconds(1).TotalMilliseconds);
