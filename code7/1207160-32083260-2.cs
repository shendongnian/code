     class MyViewModel : ViewModelBase
        {
    
            private int sliderValue;
            private string myText;
    
            public int SliderValue
            {
                get { return this.sliderValue; }
                set
                {
                    this.sliderValue = value;
                    this.OnPropertyChanged();
                }
            }
    
    
            public string MyText
            {
                get { return this.myText; }
                set
                {
                    this.myText = value;
                    this.OnPropertyChanged();
                }
            }
    
        }
