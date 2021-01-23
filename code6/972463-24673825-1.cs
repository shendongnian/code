      // Remove foreach loop
      <tr>
            <td>
                @Html.DropDownList("Bookname", Model.Select(m => new SelectListItem() { Text = m.BookName, Value = m.Bookname} ).ToList())
            </td>
            <td>
                 @Html.DropDownList("Authorname", Model.Select(m => new SelectListItem() { Text = m.Authorname, Value = m.Authorname} ).ToList())
            </td>
            <td>
                 @Html.DropDownList("Publishername", Model.Select(m => new SelectListItem() { Text = m.Publishername, Value = m.Publishername} ).ToList())
            </td>
      <td> </td>
      </tr>
