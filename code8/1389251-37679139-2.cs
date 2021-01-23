    class RadioCtl
    {
        private List<RadioButton> buttons { get; set; }
        private bool auto = false;
        public RadioCtl()
        { buttons = new List<RadioButton>(); }
        public int  RegisterRB(RadioButton rb)
        {
            if (!buttons.Contains(rb))
            {
                buttons.Add(rb);
                rb.CheckedChanged += rb_CheckedChanged;
            }
            return buttons.IndexOf(rb);
        }
        void rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbClicked = sender as RadioButton;
            if (rbClicked == null || auto) return;
            auto = true;
            foreach (RadioButton rb in buttons)
            {
                if ((rb != rbClicked)  && (rb.Parent != rbClicked.Parent) ) 
                    rb.Checked = false;
            }
            auto = false;
        }
        public void UnregisterRB(RadioButton rb)
        {
            if (buttons.Contains(rb))
            {
                buttons.Remove(rb);
                rb.CheckedChanged -= rb_CheckedChanged;
            }
        }
        public void Clear() 
        { 
            foreach(RadioButton rb in buttons) UnregisterRB(rb);
        }
        public int IndexOfRB(RadioButton rb)  { return buttons.IndexOf(rb); }
    }
