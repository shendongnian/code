    @model TableVM
    ....
    <table>
      @for(int r = 0; r < Model.Rows.Count; r++)
      {
        <tr>
          for (int c = 0; c < Model.Rows[r].Cells.Count; c++)
          {
            <td>@Html.TextBoxFor(m => m.Rows[r].Cells[c].Value</td>
          }
        </tr>
      }
    </table>
