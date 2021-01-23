        public ICommand MyCommand
                {
                    get
                    {
                        return new RelayCommand((textBoxText) =>
                        {
                            if (...)
                            {
                                //somelogic;
                            }
                            
                        });
                    }
                }
