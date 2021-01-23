    private DelegateCommand<CheckServerItem> selectionChangedCommand;
        public DelegateCommand<CheckServerItem> SelectionChangedCommand
        {
            get
            {
                return this.selectionChangedCommand ?? (this.selectionChangedCommand = new DelegateCommand<CheckServerItem>((x) =>
                {
                    if (x.IsChecked)
                    {
                        MyOtherList.Add(x);
                    } else
                    {
                        MyOtherList.Remove(x);
                    }
                }));
            }
        }
