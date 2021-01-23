    @{int count = Model.HeadingsList.Count;}
    <table>
        <thead>
            <tr>
                @foreach (string heading in Model.HeadingsList)
                {
                    <th>@heading</th>
                }
            </tr>
        </thead>
        <tbody>
            @foreach (string row in Model.rowsList)
            {
                string[] cellValues = Array.ConvertAll(row.Split(','), p => p.Trim());
                if (count != cellValues.Count()) { return; } 
                <tr>
                    @for (int i = 0; i < @count; i++) 
                    {
                                <td>@cellValues[i]</td>
                    }
                </tr>
            }
        </tbody>
    </table>
