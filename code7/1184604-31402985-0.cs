    public call Category
    {
       //.
       //.
       //.
       public virtual List<Subcategory> Subcategories{get;set;}    
    }
    <ul>
        @foreach (var item in Model.Categories)
        {
            <li>
                @item.Name
                <ul>
                    @foreach (var sub in item.Subcategories)
                    {
                        <li>@sub.Name</li>
                    }
                </ul>
            </li>
        }
    </ul>
