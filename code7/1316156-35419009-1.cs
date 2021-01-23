    public class MyViewCell
        : ViewCell
    {
        public MyViewCell()
        {
            Label objLabel = new Label();
            objLabel.Text = "Hello";
            objLabel.SetBinding(Label.BackgroundColorProperty, "TheBackgroundColor");
            this.View  = objLabel;
        }
    }
