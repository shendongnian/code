    public CH_Info()
    {
        InitializeComponent();
        MyChcreation = Application.OpenForms.OfType<Ch_Creation>().FirstOrDefault();
    }
    private void UpdateBtn_Click(object sender, EventArgs e)
    {
        if(MyChcreation != null)
        {
            StrResLbl.Text = MyChcreation.StrTotalLbl.Text;
            DexResLbl.Text = MyChcreation.DexTotalLbl.Text;
            ConResLbl.Text = MyChcreation.ConTotalLbl.Text;
            WisResLbl.Text = MyChcreation.WisTotalLbl.Text;
            IntResLbl.Text = MyChcreation.IntTotalLbl.Text;
            ChaResLbl.Text = MyChcreation.ChaTotalLbl.Text;
        }
        else
        {
            StrResLbl.Text = "";
            DexResLbl.Text = "";
            ConResLbl.Text = "";
            WisResLbl.Text = "";
            IntResLbl.Text = "";
            ChaResLbl.Text = "";
        }
    }
