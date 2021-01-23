    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    namespace TestApplication
    {
        public class BMIListItem
        {
            public BMIListItem(string name, float value)
            {
                Name = name;
                Value = value;
            }
            public BMIListItem(float value)
            {
                Name = value.ToString();
                Value = value;
            }
            public String Name { get; set; }
            public float Value { get; set; }
        }
        public class BMIViewModel : INotifyPropertyChanged
        {
            public BMIViewModel()
            {
                //  Of course you would write loops for these in real life.
                //  You should not need help with that. 
                Heights = new List<BMIListItem>
                {
                    new BMIListItem("Bitte auswählen", float.NaN),
                    new BMIListItem("Dummy", 0),
                    new BMIListItem(150),
                    new BMIListItem(151),
                    new BMIListItem(152),
                    //  etc. 
                };
                Weights = new List<BMIListItem>
                {
                    new BMIListItem("Bitte auswählen", float.NaN),
                    new BMIListItem("Dummy", 0),
                    new BMIListItem(40),
                    new BMIListItem(41),
                    new BMIListItem(42),
                    //  etc.
                };
            }
            public List<BMIListItem> Heights { get; private set; }
            public List<BMIListItem> Weights { get; private set; }
            #region BMI Property
            private float _bmi = 0;
            public float BMI
            {
                get { return _bmi; }
                set
                {
                    if (value != _bmi)
                    {
                        _bmi = value;
                        OnPropertyChanged("BMI");
                    }
                }
            }
            #endregion BMI Property
            #region Height Property
            private float _height = float.NaN;
            public float Height
            {
                get { return _height; }
                set
                {
                    if (value != _height)
                    {
                        _height = value;
                        UpdateBMI();
                        OnPropertyChanged("Height");
                    }
                }
            }
            #endregion Height Property
            #region Weight Property
            private float _weight = float.NaN;
            public float Weight
            {
                get { return _weight; }
                set
                {
                    if (value != _weight)
                    {
                        _weight = value;
                        UpdateBMI();
                        OnPropertyChanged("Weight");
                    }
                }
            }
            #endregion Weight Property
            private void UpdateBMI()
            {
                if (float.IsNaN(Weight) || float.IsNaN(Height) || Height == 0)
                {
                    BMI = 0;
                }
                else
                {
                    BMI = Weight / Height;
                }
            }
            #region INotifyPropertyChanged
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged(String propName)
            {
                var handler = PropertyChanged;
                if (null != handler)
                {
                    handler(this, new PropertyChangedEventArgs(propName));
                }
            }
            #endregion INotifyPropertyChanged
        }
    }
