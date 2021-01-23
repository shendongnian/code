     [HttpPost]
        public ActionResult UpdateOrderHoldingsForSections(string sections)
        {
            List<OrderHoldings> sectionsHoldings;
            JavaScriptSerializer seriliazer = new JavaScriptSerializer();
            sectionsHoldings = seriliazer.Deserialize<List<OrderHoldings>>(sections);
            .
            .
            .
        }
