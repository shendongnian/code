     public ICommand EnemyPopupTooltip
            {
                get
                {
                    if (this.enemyPopupTooltip == null)
                    {
                        this.enemyPopupTooltip = new RelayCommand<object>(this.ExecuteEnterCommand, this.CanExecuteEnterCommand);
                    }
    
                    return this.enemyPopupTooltip;
                }
            }
    
    
            private ICommand enemyPopupTooltip;
