    @using System.Reflection;
    @using System.Text;
    @{
        Layout = null;
    }
    @model IGenericContainer
    @{
        IEnumerable<PropertyInfo> properties = null;
        if (Model.Data.Count > 0)
        {
            properties = Model.Data[0].GetType().GetProperties();
        }
    }
    <div>
    @if (properties != null)
    {
        <table>
            <thead>
                <tr>
                    @foreach (var prop in properties)
                    {
                        <td>@prop.Name</td>
                    }
                </tr>
            </thead>
            <tbody>
                @for (int i = 0; i < Model.Data.Count; i++)
                {
                    <tr>
                    @foreach (var prop in properties)
                    {
                        <td>@prop.GetValue(Model.Data[i])</td>
                    }
                    </tr>
                }
            </tbody>
        </table>
    }
    </div>
