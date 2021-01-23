    [Required]
        public IList<ListProductViewModel> Products { get; set; }
     @for (int i = 0; i < Model.Products.Count(); i++)
                                    {
                                        <tr id=@Model.Products[i].Id>
                                            <td>@(rowNo++).</td>
                                            <td>@Html.DisplayFor(modelItem => Model.Products[i].Name)</td>
                                            <td>@Html.DisplayFor(modelItem => Model.Products[i].Description)</td>
                                            <td>@Html.DisplayFor(modelItem => Model.Products[i].Price)</td>
                                            <td>@Html.DisplayFor(modelItem => Model.Products[i].Tax)</td>
                                            <td>@Html.DisplayFor(modelItem => Model.Products[i].MeasureUnit)</td>
                                            <td>@Html.DisplayFor(modelItem => Model.Products[i].Currency)</td>
                                            <td>@Html.NumberTextBoxFor(modelItem => Model.Products[i].Quantity)</td>
                                            <td>@Html.CheckBoxBoxFor(modelItem => Model.Products[i].IsSelected)</td>
                                        </tr>
                                    }
