    public Training_Form(Form _Parent)
    {
        InitializeComponent();
        Parent = _Parent;
        Face = Parent.Face;
        //Face = new HaarCascade(Application.StartupPath + "/Cascades/haarcascade_frontalface_alt2.xml");
        ENC_Parameters.Param[0] = ENC;
        Image_Encoder_JPG = GetEncoder(ImageFormat.Jpeg);
        initialise_capture();
    }
