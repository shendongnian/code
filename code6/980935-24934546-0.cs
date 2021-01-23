    ViewBag.Title = "";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var cityRepo = new Repository<City>();
    var listItemsCities = cityRepo.GetAll().Select(city => new ListItem() {
        Value = city.Id.ToString(),
        Text = city.Value
      }).ToList();
    }
    @foreach (var order in Model) {
                            <tr>
                                @using (Html.BeginForm("UpdateDispatcherFromForm", "Home", FormMethod.Post)) {
                                    @Html.AntiForgeryToken()
                                    @Html.ValidationSummary(true)
                                    <td>
                                        @Html.HiddenFor(x => order.Id)
                                    </td>
                                    <td>
                                        @Html.DropDownListFor(m=>m.CityId, new SelectList(listItemsCities, "Value", "Text", order.CityId), "")
                                        @*@if (order.City != null) {
                                            @order.City.Value
                                        }*@
                                    </td>
                                    <td>
                                        @Html.EditorFor(x => order.Address)
                                        @*@order.Address*@
                                    </td>
                                    <td>
                                        <input type="submit" value="Save" />
                                    </td>
                                }
                            </tr>
                        }
