    {
    SqlConnection con = new SqlConnection("Server=Darkover;uid=<username>;pwd=<strong password>;database=northwind");
    SqlDataAdapter da = new SqlDataAdapter("Select * From MyImages", con);
    SqlCommandBuilder MyCB = new SqlCommandBuilder(da);
    DataSet ds = new DataSet("MyImages");
    
    byte[] MyData= new byte[0];
    			
    da.Fill(ds, "MyImages");
    DataRow myRow;
    myRow=ds.Tables["MyImages"].Rows[0];
               
    MyData =  (byte[])myRow["imgField"];
    int ArraySize = new int();
    ArraySize = MyData.GetUpperBound(0); 
    
    FileStream fs = new FileStream(@"C:\winnt\Gone Fishing2.BMP", FileMode.OpenOrCreate, FileAccess.Write);
    fs.Write(MyData, 0,ArraySize);
    fs.Close();
    }
