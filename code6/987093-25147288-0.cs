        [DelimitedRecord("|")]
        public class TBFtable 
	{ 
	    public string IdProduit; 
	    public DateTime Mois; 
	    public float Reel; 
	    public float Budget; 
         
	} 
        protected void UploadF(object sender, EventArgs e)
        {
            string excelPath = Server.MapPath("~/Files/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(excelPath);
            SqlServerStorage storage = new SqlServerStorage(typeof(TBFtable),ConfigurationManager.ConnectionStrings["bd"].ConnectionString);
             storage.InsertSqlCallback = new InsertSqlHandler(GetInsertSqlCust);
           
            TBFtable[] res = CommonEngine.ReadFile(typeof(TBFtable), excelPath) as TBFtable[]; 
	        storage.InsertRecords(res);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Données enregistrées avec succès !')", true);
        }
        protected string GetInsertSqlCust(object record) 
	{ 
	    TBFtable obj = (TBFtable) record; 
	 
	    return String.Format("INSERT INTO TF (IdProduit, Mois, Reel, Budget ) " +  " VALUES ( '{0}' , '{1}' , '{2}' , '{3}'  ); ", obj.IdProduit, obj.Mois,obj.Reel, obj.Budget ); 
	 
	} 
