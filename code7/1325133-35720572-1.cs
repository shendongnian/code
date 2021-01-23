    class Number {
        public int NumberValue { get; set; }
        public RadioButton ShowVisible { get; set; }
        public TextBox CodeTextBox { get; set; }
        public TextBox GradeTextBox { get;set; }
        public void SetVisible()
        {
             this.CodeTextBox.Visible = this.ShowVisible.Checked;
             this.GradeTextBox.Visible = this.ShowVisible.Checked;
        }
    }
