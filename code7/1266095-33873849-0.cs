    void B(dynamic[] a){
       var arrDataList = a;
       foreach (var item in arrDataList)
       {
           item.dlName.DataSource = new ServiceReference1.Service1Client().GetProductBestSeller(item.idCate); // throw error
           item.dlName.DataBind(); // throw error
       }
    }
