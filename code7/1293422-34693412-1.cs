    bool _IsForm1ValueChecked;
    //By this property text will be exposed to outside of Form
    public string ReturnValue { get { return this.textbox1.Text;} }
    public Form2(bool isForm1ValueChecked)
    {
        _IsForm1ValueChecked = isForm1ValueChecked;
    }
