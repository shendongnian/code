    public RadioButton radioButton { get; set; }
    public LinkButton linkbutton { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        SetCtrlProperties();
    }
    private void SetCtrlProperties(){
        dropdown = ddl;
        radioButton = rbtn;
        linkbutton = lbtn;
    }
