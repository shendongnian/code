    class BMICalc :INotifyPropertyChanged
        {
            private double _heightFt = 0;
            private double _heightIn = 0;
            private double _heightCm = 0;
            private double _weightLbs = 0;
            private double _weightKg = 0;
            private double _bmi = 0;
            private string _category = null;
            private string _error = null;
    
            public double heightFt
            {
    
                get { return _heightFt; }
                set
                {
                    _heightFt = value;
                    OnPropertyChanged("heightFt");
                }
    
            }
    
            public double heightIn
            {
    
                get { return _heightIn; }
                set
                {
                    _heightIn = value;
                    OnPropertyChanged("heightIn");
                }
    
            }
    
            public double heightCm
            {
                get { return _heightCm; }
                set
                {
                    _heightCm = value;
                    OnPropertyChanged("heightCm");
                }
    
            }
    
            public double weightLbs
            {
    
                get { return _weightLbs; }
                set
                {
                    _weightLbs = value;
                    OnPropertyChanged("weightLbs");
                }
    
            }
    
            public double weightKg
            {
    
                get { return _weightKg; }
                set
                {
                    _weightKg = value;
                    OnPropertyChanged("weightKg");
                }
    
            }
    
            public double bmi
            {
                get { return _bmi; }
                set
                {
                    _bmi = value;
                    OnPropertyChanged("bmi");
                }
            }
    
            public string error
            {
                get { return _error; }
                set
                {
                    _error = value;
                    OnPropertyChanged("error");
                }
            }
    
            public string category
            {
                get { return _category; }
                set
                {
                    _category = value;
                    OnPropertyChanged("category");
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string propertyName){
    
                if(PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    
            }
    
            public void doCalculation(string calculationMode){
                if(calculationMode == "Imperial"){
    
                    if (heightFt == null)
                    {
                        this.error = "You must provide a value for your height in feet!";
                    }
                    else if (heightIn == null)
                    {
                        this.error = "You must provide a value for your height in inches!";
                    }
                    else if (weightLbs == null)
                    {
                        this.error = "You must provide a value for your weight in pounds!";
                    }
                    else
                    {
                        heightFt = Convert.ToDouble(heightFt);
                        heightIn = Convert.ToDouble(heightIn);
                        weightLbs = Convert.ToDouble(weightLbs);
    
                        _weightKg = Convert.ToDouble(_weightLbs * (1 / 2.2));
                        _heightCm = Convert.ToDouble((_heightFt + (_heightIn / 12) / 0.032808));
                    }
    
                } else if(calculationMode == "Metric"){
    
                        this.bmi = weightKg / Math.Pow((heightCm / 100), 2);
    
                        if (this.bmi < 18.5)
                        {
                            this.category = "underweight";
                        }
                        else if (this.bmi >= 18.5 && this.bmi < 24.9)
                        {
                            this.category = "normalweight";
                        }
                        else if (this.bmi >= 25 && this.bmi <= 29.9)
                        {
                            this.category = "overweight";
                        }
                        else if (this.bmi > 30)
                        {
                            this.category = "obese";
                        }
    
                    }
    
                }
            }
        }
