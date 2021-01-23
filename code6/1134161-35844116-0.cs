         @Html.LabelFor(model => model.ItemType, new { @class = "control-label" })
         @Html.DropDownList("ItemType", (IEnumerable<SelectListItem>)ViewBag.ItemTypes, new { @class = "form-control" })
         @Html.ValidationMessageFor(model => model.ItemType, null, new { @class = "text-danger" })
     </div>
------------------------------------------------------------------------------
            var types = new List<SelectListItem>();
            types.Add(new SelectListItem() { Text = "Select...", Value = string.Empty });
            types.Add(new SelectListItem() { Text = "OTC", Value = "0" });
            types.Add(new SelectListItem() { Text = "Generic", Value = "1" });
            types.Add(new SelectListItem() { Text = "Brand", Value = "2" });
            types.Add(new SelectListItem() { Text = "Non-Merchandise", Value = "9" });
            ViewBag.ItemTypes = types;
