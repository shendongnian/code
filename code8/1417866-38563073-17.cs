    public class your_control : UserControl
    {
        public TextBox tb { get; private set; }
        public Button bu { get; private set; }
        private Grid container;
        public your_control (/* your params*/)
        {
            this.tb = this.build_textbox();
            this.bu = this.build_button();
            this.container = new Grid();
            this.Content = this.container;
            this.container.Children.Add(this.tb);
            this.container.Children.Add(this.bu);
        }
        private TextBox build_textbox()
        {
            TextBox tb = new TextBox();
            return tb;
        }
        private Button build_button()
        {
            Button bu = new Button();
            return bu;
        }
    }
