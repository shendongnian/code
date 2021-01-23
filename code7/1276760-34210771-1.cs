        [ChildActionOnly]
        public ActionResult DisplayProduct(int productID)
        {
            var product = // retrieve product by id;
            return PartialView("_Product", product);
        }
    Then, in your view:
        @Html.Action("DisplayProduct", new { productID = Request["productID"] })
