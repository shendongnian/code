     [ActionName("PDFVIEW")]
        public ActionResult pdf(int ticketnumber)
        {
            var db = new ScaleTrac_VerticalEntities();
            Ticket_UnsettledScaleImages tu = new Ticket_UnsettledScaleImages();
            tu = db.Ticket_UnsettledScaleImages.Where(p => p.UnsettledID == ticketnumber).First();
            string filename = "ScaleTick" + tu.UnsettledID + ".pdf";
            {
                byte[] bytes = tu.ScaleTicket;
                TempData["bytes"] = bytes;
                Response.Clear();
                MemoryStream ms = new MemoryStream(bytes);
                var fName = string.Format("File-{0}.pdf", DateTime.Now.ToString("s"));
                Session[fName] = ms;
                return Json(new { success = true, fName }, JsonRequestBehavior.AllowGet);
            }
        }
            public ActionResult DownloadFile(string fName)
                {
                 var ms = Session[fName] as MemoryStream;
                     if (ms == null)
                     return new EmptyResult();
                     Session[fName] = null;
                     return File(ms, "application/pdf", fName);
                }
