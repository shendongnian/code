        AutoResetEvent _waitHandle = new AutoResetEvent(false);
        List<string> _writeCache = new List<string>();
        bool _threadRunning = false;
        void WriteToFile(string text)
        {
            lock (_writeCache)
            {
                _writeCache.Add(text);
                _waitHandle.Set();
                if(_threadRunning)
                {
                    return;
                }
                _threadRunning = true;
            }
            Task.Run(async () =>
            {
                while (true)
                {
                    _waitHandle.WaitOne();
                    StorageFile file = await folder.GetFileAsync(logFileName);
                    using (var f = await file.OpenStreamForWriteAsync())
                    {
                        using (StreamWriter writer = new StreamWriter(await file.OpenStreamForWriteAsync()))
                        {
                            lock (_writeCache)
                            {
                                while (_writeCache.Count > 0)
                                {
                                    string s = _writeCache[0];
                                    _writeCache.RemoveAt(0);
                                    writer.Write(s);
                                }
                            }
                        }
                    }
                }
            });
        }
