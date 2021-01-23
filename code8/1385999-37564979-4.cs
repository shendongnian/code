      for (int i = 0; i < _paralellTaskCount; i++)
            {
                object message;
                int counter = CheckCounter(message);
                if (counter >= 0)
                {
                    var task = Task.Run(() => CalcSingle(_personnelIds[counter].Item1));
                    var continuation = task.ContinueWith((antecedent) => CalcSingle(_personnelIds[counter].Item1),
                        TaskContinuationOptions.OnlyOnRanToCompletion);
                }
            }
