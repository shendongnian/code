     Command = new RelayCommand(param => this.CommandAction(param));
        }
        public RelayCommand Command { get; set; }
        private void CommandAction(object param)
        {
            var xModelProperty = param as XModelProperty;
        }
