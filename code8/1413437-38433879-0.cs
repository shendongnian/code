    ViewModel
        class MyVM : MVVM.ViewModel.ViewModelBase
        {
            private string name1;
            public string Name1
            {
                get { return name1; }
                set {
                    name1 = value;
                    OnPropertyChanged(() => Name1);
                }
            }
            string name1Conf;
            public string Name1Conf
            {
                get { return name1Conf; }
            }
            private string name2;
            public string Name2
            {
                get { return name2; }
                set
                {
                    name2 = value;
                    OnPropertyChanged(() => Name2);
                }
            }
            string name2Conf;
            public string Name2Conf
            {
                get { return name2Conf; }
            }
    
            private bool commitMe;
    
            public bool CommitMe
            {
                get { return commitMe; }
                set {
                    commitMe = value;
                    OnPropertyChanged(() => CommitMe);
                    if (commitMe)
                    {
                        DoCommit();
                    } 
                }
            }
    
            private void DoCommit()
            {
                name1Conf = name1;
                name2Conf = name2;
                OnPropertyChanged(() => Name1Conf);
                OnPropertyChanged(() => Name2Conf);
            }
        }
