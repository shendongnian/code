            void test() {
                Settings.Default.PropertyChanged += Default_PropertyChanged;
            }
    
            private void Default_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "MyProperty")
                {
                     var tValue = Settings.Default.PropertyValues[e.PropertyName].PropertyValue.ToString();
                     toolStripStatusLabelMessage.Text = String.Format("Property {0} changed to {1} ", e.PropertyName , tValue);
                }
            }
