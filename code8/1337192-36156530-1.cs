        protected void Page_Load(object sender, EventArgs e)
        {
            int id_sdg = Convert.ToInt32(Page.Request["idSdg"]);
            using (DAL.AGEntities db = new DAL.AGEntities())
            {
                var courriels = BigQuery(db);
                string liste = BLL.ConstructeurString.BuildCsv(courriels);
                ExporterFichier("ListeCourriels-" + id_sdg.ToString() + ".csv", "text/csv", liste);
            }
        }
