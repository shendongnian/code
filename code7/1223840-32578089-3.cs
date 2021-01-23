    public ICommand GetCommand
            {
                get
                {
                    return getCommand ?? (getCommand = new RelayCommand(p=>this.Get(), p=>this.CanGet()));
                }
            }
