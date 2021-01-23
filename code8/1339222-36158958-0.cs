     private void urn_Click(object sender, EventArgs e)
            {
                // Hi 
                // ım add new product from here
                SimpleButton urun = (SimpleButton)sender;
                UrunID = Convert.ToInt16(urun.Tag);
                DataRow Dr = cls.urunSec(UrunID);
                Ses2();
                gridView1.AddNewRow();
                gridView1.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "ID", Dr["ID"].ToString());
                gridView1.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "STOKADI", Dr["STOKADI"].ToString());
                gridView1.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "MIKTAR", Adet);
                gridView1.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "BIRIMFIYAT", Dr["SATISFIYAT"].ToString());
                Hesapla();
            } 
    I have added , but did not
