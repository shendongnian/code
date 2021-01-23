    @for (int i = 0; i < Model.Count; i++)
          {
            <tr>
              <td style="text-align: center;" class="Cell">
                @Html.CheckBoxFor(m => Model[i].Selected)
              </td>
              <td class="Cell">
                @Html.DisplayFor(m => Model[i].Name)
                @Html.HiddenFor(m => Model[i].Name)
              </td>
              <td class="Cell">
                @Html.DisplayFor(m => Model[i].AddressPhysical)
                @Html.HiddenFor(m => Model[i].AddressPhysical)
              </td>
              <td class="Cell">
                @Html.DisplayFor(m => Model[i].AddressPhysicalPostCode)
                @Html.HiddenFor(m => Model[i].AddressPhysicalPostCode)
              </td>
            </tr>
          }
