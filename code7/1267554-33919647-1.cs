    public class MyButton : Button
    {   
        public MyButton()
        {
            ....
            var controlExtension = ControlExtension.GetControlExtension(this);
        }
        public IControlExtension { get { return controlExtension; } }
    }
