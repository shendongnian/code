    //Person
    @model MvcApplication1.Models.Person
    @{
         ViewBag.Title = "Index";    
     }
    <h2>Person</h2>
    @using (Html.BeginForm("Index", "Home", FormMethod.Post))
    {
        <div>
            @Html.TextBoxFor(model => model.Id, new { id = "Id"})
        </div>
       
        <div>
            @Html.TextBoxFor(model => model.Nome, new { id = "Name" })
        </div>
    
         if (Model != null && Model.Phone != null)
         {
             foreach (var phone in Model.Phone)
             {
                 Html.RenderPartial("_Phone", phone);
             }
         }    
    
        <input type="submit" value="Save" />
    }
    //phone
    @model MvcApplication1.Models.Phone
    @using (Html.BeginCollectionItem("Phone"))
    {
         <div>
            <div>
                @Html.EditorFor(model => model.PhoneNumber)
            </div>
        </div>
    }
