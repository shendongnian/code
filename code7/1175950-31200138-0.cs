    public RelayCommand Cancel
        {
            get
            {
                return _cancel
                    ?? (_cancel = new RelayCommand(
                    () =>
                    {
                        foreach (var change in ChangesList)
                        {
                            switch (change.Action)
                            {
                                case NotifyCollectionChangedAction.Add:
                                    Clone.Remove((T)change.NewItems[0]);
                                    break;
                                case NotifyCollectionChangedAction.Remove:
                                    Clone.Insert(change.OldStartingIndex, (T)change.OldItems[0]);
                                    break;
                            }
                        }
                        Messenger.Default.Send(new NotificationMessage("Cancel"));
                    }));
            }
        }
                }
            }
