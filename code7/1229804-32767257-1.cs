            foreach (String RDFDate1 in RDFMDate)
			{
				MAppointment apt1 = new MAppointment();
                //var strOriginal = RDFDate1.Substring(4) + "/" + RDFDate1.Substring(4) + "/" + RDFDate1.Substring(0, 4);
                var strOriginal = RDFDate1.Substring(4) + "/" + RDFDate1.Substring(4) + "/" + RDFDate1.Substring(0, 4);
				DateTime dt = DateTime.Parse(strOriginal);
				apt1.StartTime = dt;
				var ACFTModel = (
					from rdfcounts in dc.RDFCounts
					where (Convert.ToString(rdfcounts.RDate.Value.Year) + Convert.ToString(rdfcounts.RDate.Value.Month)) == (RDFDate1.ToString())
					group rdfcounts by rdfcounts.Model into g
                    //select new { MonRDF = (RDFMDate.ToString() + " " + Model = g.Key + "" + Convert.ToString(g.Sum((p) => p.RDFNUm))) }).ToArray();
                    select new { MonRDF = (RDFMDate.ToString() + " " + g.Key + "" + Convert.ToString(g.Sum((p) => p.RDFNUm))) }).ToArray();
                    
				ModelArray = ACFTModel;
