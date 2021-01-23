    public static IEnumerable<MultValoredItem> DropDownList()
    {
        var brandServices = new BrandService();
        var brandsDTO = brandServices.GetAll().OrderBy(b => b.Name);
        var brandsList = brandsDTO.Select(brand =>
        new MultValoredItem
        {
            Value1 = brand.Id.ToString(),
            Value2 =  //Another value here
            Text = brand.Name
        });
        return brandsList;
    }
    public class MultValoredItem
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public string Text { get; set; }
    }
    <ul id="sch-brand-dropdown">
      @foreach (var brand in Model.BrandList)
      {
        <li data-id1="@brand.Value1" data-id2="@brand.Value2">@brand.Text</li>
      }
    </ul>
