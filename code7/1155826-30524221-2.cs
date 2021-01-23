    @(Html.Kendo().Grid<oko.Models.OrderDtoViewModel>().Name("NewOrders").Columns(columns =>
    {       
        columns.Bound(s => s.Username);
        columns.Bound(s => s.NameSurname);
        columns.Bound(s => s.Phone);
        columns.Bound(s => s.CreateDate).Format("{0:dd/MM/yyyy}");  
    })
