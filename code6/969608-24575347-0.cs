    OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Dragonfly\\Documents\\Visual Studio 2013\\WebSites\\WebSite2\\App_Data\\calismagunluk.mdb");
    OleDbDataReader oku;
    OleDbCommand sorgu =new OleDbCommand();
    DateTime bugun = DateTime.Now.Date;
    sorgu.CommandText = "select * from calisan where kulID=@ID AND gun=@date";
    sorgu.Parameters.Add("@ID", OleDbType.TypeOfID).Value = susionKulId;
    sorgu.Parameters.Add("@date", OleDbType.DateTime).Value = bugun;
