    public class Custom_View_VM : NotificationBase
    {
        public String Color1 
        {
            get { return This.Color1; }
            set { SetProperty(This.Color1, value, () => This.Color1 = value); }
        }
        // TODO: same here
        public Brush Color2 { get; set; }
        public void  ChangeColor{//change color1 or color2};
    }
