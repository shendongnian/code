    private IList _numFilasSeleccionadas;
    
            public IList NumFilasSeleccionadas
            {
                get { return _numFilasSeleccionadas; }
                set 
                { 
                    _numFilasSeleccionadas = value;
                    RaisePropertyChanged("NumFilasSeleccionadas");
                }
            }
    
    private void RegisterCommands()
            {
                Messenger.Default.Register<IList>(this, d => this.NumFilasSeleccionadas = d);
            }
