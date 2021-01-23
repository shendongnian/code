    private void MySlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
    {     
        BindingExpression be = slid.GetBindingExpression(Slider.ValueProperty);
        be.UpdateSource();
    }
