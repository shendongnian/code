    class ButtonLabel
    {
        Label Label;
        Button Button;
        public ButtonLabel(Button Button, Label Label)
        {
            this.Label = Label;
            this.Button = Button;
        }
        public void HideIfEmpty()
        {
            if(Label.Text=="")
                Button.Visible = false;
        }
    }
