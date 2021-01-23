            private bool _devoExibirOpcoesParaPainel;
            public bool DevoExibirOpcoesParaPainel
            {
                get { return _devoExibirOpcoesParaPainel; }
                set
                {
                    if (value != _devoExibirOpcoesParaPainel)
                        _devoExibirOpcoesParaPainel = value;
                    RaisePropertyChanged("DevoExibirOpcoesParaPainel");
                    RaisePropertyChanged("DevoExibirOpcoesParaBandeja");
                }
            }
        
           
            public bool DevoExibirOpcoesParaBandeja
            {
                get { return !DevoExibirOpcoesParaPainel; }                
            }
    
