        public class FlotSeries
        {
            public List<double[]> data;
            public string label;
        }
        public ActionResult Test()
        {
            FlotSeries flotSeries = new FlotSeries();
            flotSeries.label = "Series1";
            flotSeries.data = new List<double[]>();
            flotSeries.data.Add(new double[] { (DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds * 1000, 23.0 });
            flotSeries.data.Add(new double[] { (DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds * 1000, 12.0 });
            return Json(flotSeries, JsonRequestBehavior.AllowGet);
        }
