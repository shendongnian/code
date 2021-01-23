    {
        BaiXeDTO obj = new BaiXeDTO();      //Map all to define database 
        txtKhuVucBai.Text = mReader.CurrentCardIDBlock1.ToString();
        txtMaThe.Text = mReader.CurrentCardIDBlock2.ToString();
        //If I comment all below code. It's work. But I need Insert data to database.
        txtKhuVucBai.Text = obj.IDBaiXe.ToString();
        txtMaThe.Text = obj.IDRF.ToString();
        obj.BienSoXe = textBox1.Text;
        obj.HinhBienSo = color.ToString();
        obj.HinhChuXe = img.ToString();
        obj.ThoiGianVao = DateTime.Now.ToLocalTime();
        obj.ThoiGianRa = DateTime.Now.ToLocalTime();
        baixe.BaiXe_Insert(obj); //Contain data access layer to insert data with store procedure.
    }
