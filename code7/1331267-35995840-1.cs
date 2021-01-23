    public void Subscribe(MainWindowViewModel m)
            {
                m.Tick += new MainWindowViewModel.MyHandler(HeardIt);
            }
            private void HeardIt(ViewModelBase m, EventArgs e)
            {
                if (m != null)
                {
                    if ((bool)(((UI.Viewmodel.MainWindowViewModel)m).IsPopupOpen))
                        IsUpperWSUsrCtlVisible = false;
                    else
                        IsUpperWSUsrCtlVisible = true;
                }
                CommandManager.InvalidateRequerySuggested();
                
                //_dispatcher.BeginInvoke(DispatcherPriority.DataBind,
                //        new DispatcherOperationCallback(ScheduleTransferOperation),
                //        null);
            }
