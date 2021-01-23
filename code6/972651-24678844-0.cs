        [HttpGet]
		[Route("~/services/mrf/{mrfnumber}")]						// GET specific MRF
		public Mrf GetMrfRecord(string mrfnumber) {
			using (var ddc = new MRFDataContext(ConnectionString)) {
				var options = new DataLoadOptions();
				options.LoadWith((Mrf c) => c.MRFParts);	//immediate load related MRFParts
				ddc.LoadOptions = options;
				var mrf = (from u in ddc.Mrfs
						   where u.MrfNum == mrfnumber
						   select u).FirstOrDefault();
				return mrf ?? null;
			}
		}
