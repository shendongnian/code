    public class MyCustomButton : Button
    {
        protected override bool ShowFocusCues
        {
            get { return this.Focused; }
        }
    }
