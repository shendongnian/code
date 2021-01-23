    @model MvcApplication1.Models.ContactModel 
    @{
        ViewBag.Title = "Contact";
    }
    @using (Html.BeginForm("SaveContact", "Home", Model, FormMethod.Post))
    {
        @Html.DisplayFor(m => m.Message);
        <button type="submit">Submit</button>
    }
