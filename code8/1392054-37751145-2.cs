    @model System.Collections.Generic.List<System.Data.DataRow>
    
    <table>
        <thead>
            <tr>
                @foreach (System.Data.DataRow row in Model)
                {
                    foreach(System.Data.DataColumn col in row.Columns)
                    {
                      <th>@col.ColumnName</th>
                    }
                }
            </tr>
        </thead>
        <tbody>
            @foreach (System.Data.DataRow row in Model)
            {
              <tr>
               @foreach (DataColumn col in Model.Columns)
               {
                   <td>@row[col.ColumnName]</td>
               }
              </tr>
            }
        </tbody>
    </table>
