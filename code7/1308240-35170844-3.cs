        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            //
            if (e.PropertyName == "MyTextColor")
            {
                SetPickerTextColor((this.Element as CustomPicker2).MyTextColor);
            }
        }
