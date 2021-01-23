        protected void BoucleInfini()
        {
            while (0==0)
            {
                BLL.Rappel.RetardCheckUp(System.Web.Hosting.HostingEnvironment.MapPath("~/_inc/courriels"));
                Thread.Sleep(1000 * 60 * 60 * 24);
            }
        }
