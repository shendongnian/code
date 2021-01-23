            switch (e.ProgressPercentage)
            {
                case -1:
                    listBoxMessages.Invoke(new MethodInvoker(delegate
                    {
                        listBoxMessages.Items.Add(e.UserState.ToString());
                        listBoxMessages.Items.Add("");
                    }));
                    break;
                case 100:
                    listBoxMessages.Invoke(new MethodInvoker(delegate
                    {
                        listBoxMessages.Items.RemoveAt(listBoxMessages.Items.Count - 1);
                        listBoxMessages.Items.Add(e.UserState.ToString());
                    }));
                    break;
                default:
                    listBoxMessages.Invoke(new MethodInvoker(delegate
                    {
                       listBoxMessages.Items.RemoveAt(listBoxMessages.Items.Count - 1);
                       listBoxMessages.Items.Add(string.Format(e.UserState.ToString()));
                    }));
                    progressBar.Invoke(new MethodInvoker(delegate
                    {
                    progressBar.PerformStep();
                    }));
                    break;
            }
