    @model FooViewModel
    @using (Ajax.BeginForm("CustomerFilter", "Delivery", new System.Web.Mvc.Ajax.AjaxOptions
    {
        InsertionMode = System.Web.Mvc.Ajax.InsertionMode.Replace,
        HttpMethod = "POST",
        UpdateTargetId = "deliverylist"
     }))
    {               
       @Html.TextBoxFor(m => m.From)
       @Html.TextBoxFor(m => m.To)
       @Html.DropDownListFor(m => m.CusName, new SelectList(model.AvailableCustomers, "Id", "Name"),"--Select Customer--",new { @Style = "WIDTH:169PX" })
       <input type="submit" value="View" id="BtnSubmit" />
    }
