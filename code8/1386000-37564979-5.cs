     for (int i = 0; i < _paralellTaskCount; i++)
            {
                try
                {
                    object message;
                    int counter = CheckCounter(message);
                    if (counter >= 0)
                    {
                        long res1 = await Task.Run(() => CalcSingle(_personnelIds[counter].Item1));
                        long res2 = await Task.Run(() => CalcSingle(_personnelIds[counter].Item1));
                    }
                }
                catch (AggregateException e)
                {
                    //TODO handle
                }
            }
