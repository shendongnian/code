    static void getPhoto(DataGridItem item) {
        DataRowView view = (DataRowView) item.DataItem;
        Fonksiyonlar vt=new Fonksiyonlar();
        DataTable SeriFoto = vt.GetDataTable("select foto from seriFotograf where seriilanID=" + view["ilan_id"] + " and kapak=true" + " order by seriilanID desc");
        if (SeriFoto.Rows.Count < 1)
        {
            DataRow nullPhotoRow = SeriFoto.NewRow();
            nullPhotoRow["foto"] = "0.png";
            SeriFoto.Rows.Add(nullPhotoRow);
        }
        Repeater rptReddedilenFoto = (Repeater)item.FindControl("rptReddedilenFoto");
        rptReddedilenFoto.DataSource = SeriFoto;
        rptReddedilenFoto.DataBind();
    }
