    string szCommand = "INSERT INTO Yeucaukhachhang(MaKH,MaHang,TenHang,DonViTinh,Dongia,
                SoLuong,Duyet)";
    szCommand += string.Format("values ('{0}','{1}','{2}','{3}','{4}','{5}')",
    makh.Text, metroGrid2.rows[i].cells["mahang"].Value, 
    metroGrid2.Rows[i].Cells["tenhang"].Value,
    metroGrid2.Rows[i].Cells["donvitinh"].Value, 
    metroGrid2.Rows[i].Cells["dongia"].Value, 
    metroGrid2.Rows[i].Cells["soluong"].Value);
    SqlCommand cmd = new SqlCommand(szCommand,sqlCon);
