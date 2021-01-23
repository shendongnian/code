    @model MatrixVM
    @using (Html.BeginForm())
    {
      <table>
        <tbody>
          @for(int r = 0; r < Model.Rows.Count; r++)
          {
            <tr>
              @for(int c = Model.Rows[r].Columns[c].Count; c++)
              {
                <td>
                  @Html.DropDownListFor(m => m.Rows[r].Columns[c].SelectedValue, Model.Foos)
                </td>
              }
            </tr>
          }
        <tbody>
      </table>
      <input type="submit" />
    }
    
