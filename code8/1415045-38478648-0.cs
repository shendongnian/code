    [HttpPost]
    public ActionResult IRumah(AlamatRumahModel model)
    {
    	Tbl_Alamat_Rumah rumah = new Tbl_Alamat_Rumah();
    	model = new AlamatRumahModel();  //Remove this line of code
    	using (pmbEntities db = new pmbEntities())
    	{
    		...
