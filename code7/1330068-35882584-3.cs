            IObservable<EventPattern<EventArgs>> appActivated =
                Observable
                    .FromEventPattern<EventHandler, EventArgs>(
                        h => Application.Current.Activated += h,
                        h => Application.Current.Activated -= h);
