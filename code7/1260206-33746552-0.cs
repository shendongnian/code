    [Subject("Line Item")]
    public class When_creating_a_basic_line_item_from_generic_sku()
    {
        Establish context = () => 
        {
            // you would use this if the Subject's constructor
            // required more complicated setup, mocks, etc.
        }
        Because of = () => Subject.CreateLineItem(Sku, Quantity);
        It should_be_in_some_state = () => Item.InventoryStatus.ShouldEqual(InventoryStatus.Enabled);
        private static Whatever Subject = new Whatever();
        private static BaseVariationContent Sku = new GenericSku();
        private static int Quantity = 1;
        private static ILineItem Item;
    }
