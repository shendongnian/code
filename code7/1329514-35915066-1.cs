    public DURUM Durum
        {
            get
            {
                return _durum;
            }
            set
            {
                _durum = value;
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    if (value == DURUM.DOLU)
                    {
                        BGrenk = (SolidColorBrush)(new BrushConverter()).ConvertFromString("#FF740000");
                        IptalEtMenuItem = Visibility.Visible;
                        OdemeAlMenuItem = Visibility.Collapsed;
                        DetayMenuItem = Visibility.Visible;
                    }
                    else if (value == DURUM.KOMBİNE)
                    {
                        BGrenk = (SolidColorBrush)(new BrushConverter()).ConvertFromString("#FF740000");
                        IptalEtMenuItem = Visibility.Collapsed;
                        OdemeAlMenuItem = Visibility.Visible;
                        DetayMenuItem = Visibility.Visible;
                    }
                    else if (value == DURUM.REZERVE)
                    {
                        BGrenk = (SolidColorBrush)(new BrushConverter()).ConvertFromString("#00a8e6");
                        IptalEtMenuItem = Visibility.Visible;
                        OdemeAlMenuItem = Visibility.Visible;
                        DetayMenuItem = Visibility.Visible;
                    }
                    else if (value == DURUM.KAPORA)
                    {
                        BGrenk = (SolidColorBrush)(new BrushConverter()).ConvertFromString("#ffd800");
                        IptalEtMenuItem = Visibility.Visible;
                        OdemeAlMenuItem = Visibility.Visible;
                        DetayMenuItem = Visibility.Visible;
                    }
                    else if (value == DURUM.BOŞ)
                    {
                        BGrenk = (SolidColorBrush)(new BrushConverter()).ConvertFromString("#FF00AE18");
                        IptalEtMenuItem = Visibility.Collapsed;
                        OdemeAlMenuItem = Visibility.Visible;
                        DetayMenuItem = Visibility.Collapsed;
                    }
                    OnPropertyChanged("DURUM");
                }));
            }
        }
