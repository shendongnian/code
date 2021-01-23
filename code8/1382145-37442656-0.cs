    public FormLogin frm;
     public FormUser (FormLogin frm)
        {
            InitializeComponent();
            this.frm=frm
        }
    
     private void btnHotelResort_Click(object sender, EventArgs e)
        {
            panelPicture.Visible = false;
            txtUsernameUser.Text = frm.StrUsername;
    
        }
