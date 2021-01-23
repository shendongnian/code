            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < split.Length; i++)
                {
                    Dispatcher.Invoke((Action)(() =>
                    {
                        linkRange = richEditControl1.Document.AppendText(split[i] + "\n\n");
                        hyperlink = richEditControl1.Document.CreateHyperlink(linkRange);
                    }));
                }
            });
