        private void GoOnRecordingFrames()
        {
            bool continuar = true;
            while (continuar)
            {
                using (var stream = new FileStream(CaminhoArquivo, FileMode.Append, FileAccess.Write))
                using (var writer = new BinaryWriter(stream))
                {
                    while (_frames.Count > 0)
                    {
                        Frame frame;
                        lock (_lockObj)
                        {
                            frame = _frames.Dequeue();
                        }
                        writer.Write(frame.Serializar());
                    }
                    ////// Handling Cancellation using the Token!
                    if (_cancellation_token.IsCancellationRequested)
                    {
                        writer.Write(Separadores.END_SEPARATOR);
                        continuar = false;
                    }
                }
                Thread.Sleep(100);
            }
        }
