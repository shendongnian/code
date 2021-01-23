            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < split.Length; i++)
                {
                    Dispatcher.Invoke(() => linkRange = richEditControl1.Document.AppendText(split[i] + "\n\n"));
                    Dispatcher.Invoke(() => hyperlink = richEditControl1.Document.CreateHyperlink(linkRange););
                }
            });
