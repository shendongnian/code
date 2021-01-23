    public class Custom_View_VM : NotificationBase
    {
        private Brush color1;
        public Brush Color1 
        {
            get { return color1; }
            set { SetProperty(color1, value, () => color1 = value); }
        }
        // TODO: same here
        public Brush Color2 { get; set; }
        public void  ChangeColor{//change color1 or color2};
    }
