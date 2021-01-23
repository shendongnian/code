    public class TestModel
        {
            public IList<int> Quantities { get; set; }
            public int SelectedQuantity { get; set; }
            public IList<SelectListItem> QuantitiesSelectListItems
            {
                get
                {
                    var list = (from item in Quantities
                                select new SelectListItem()
                                {
                                    Text = item.ToString(),
                                    Value = item.ToString(CultureInfo.InvariantCulture),
                                }).ToList();
    
                    return list;
                }
            }
    
            public TestModel()
            {
                Quantities=new List<int>();
            }
        }
