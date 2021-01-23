    public class MyClass()
    {
        public MyClass()
        {
            // attach property changed in constructor
            this.PropertyChanged += MyClass_PropertyChanged;
        }
    
        private void MyClass_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "HoldingPen")
                OnHoldingPenCheckChanged();
        }
    
        public bool HoldingPen
        {
            get{ m_holdingPen; }
            set
            {
                if (m_hodingPen == value)
                    return; 
                m_hodingPen=value;
                onPropertyChanged("HoldingPen");
            }
        }
    
        public void OnHoldingPenCheckChanged()
        {
            if(HoldingPen && some other condition)
            {
                HoldingPen=false;  //Here view should be updated simultaneously 
            }
        }
    }
