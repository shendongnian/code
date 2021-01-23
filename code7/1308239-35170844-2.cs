    public class CustomPicker2Renderer
        : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            var picker = e.NewElement;
            CustomPicker2 bp = (CustomPicker2)this.Element;
            if (this.Control != null)
            {
		        var pickerStyle = new Style(typeof(Picker))
                {
                    Setters = {
                         new Setter {Property = Picker.BackgroundColorProperty, Value = bp.MyBackgroundColor},
                    }
                };
                SetPickerTextColor(bp.MyTextColor); 
		        picker.Style = pickerStyle;
            }	    
	     }
	    private void SetPickerTextColor(Xamarin.Forms.Color pobjColor)
        {
            byte bytR = (byte)(pobjColor.R * 255);
            byte bytG = (byte)(pobjColor.G * 255);
            byte bytB = (byte)(pobjColor.B * 255);
            byte bytA = (byte)(pobjColor.A * 255);
            //
            ((System.Windows.Controls.Control)(((System.Windows.Controls.Panel)this.Control).Children[0])).Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(bytA, bytR, bytG, bytB));
        }
