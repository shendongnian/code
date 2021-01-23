    @foreach (var item in Model)
    {
      ....
      <td>
        @using (Html.BegnForm("Delete", "yourControllerName", new { id = item.ID, version = item.version }))
        {
          <input type="submit" value="Delete" /> // style it to look like a link if that's what you want
        }
      </td>
      ....
    }
