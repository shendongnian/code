    private string dummySel;
    public string DummySel
    {
        get { return dummySel; }
        set { dummySel = value;
            //OnPropertyChanged(() => DummySel);
        }
    }
    private int dummySelection;
    public int DummySelection {
        get { return dummySelection;  }
        set {
            dummySelection = value;
            //OnPropertyChanged(()=>DummySelection); 
        }
    }
