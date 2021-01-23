    class Form3
    {
        Form1 _parent;
        public Form3(Form1 parent)
        {
            _parent = parent;
        }
    
        public void Method()
        {
            _parent.webbrowser1.navigate(listbox1.selecteditem.tostring());
            this.Visible = false;
        }
    }
