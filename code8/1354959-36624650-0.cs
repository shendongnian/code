                var tl = new Task[pdList.Count];
                for (int i = 0; i < pdList.Count; i++)
                {
                    int li = i; // i is shared...use local copy
                                // use foreach instead
                    tl[i] = Task.Factory.StartNew(() => ExecuteProcess(pdList[li], hargs), TaskCreationOptions.LongRunning);
                }
