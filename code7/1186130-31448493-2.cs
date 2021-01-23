    @using System.ComponentModel.DataAnnotations
    @using System.Reflection
    @foreach (var item in Model.GetType().GetProperties())
    {
            var label = item.GetCustomAttribute<DisplayAttribute>().Name;
            var value = item.GetValue(Model);
            <div class="row">
                <p class="label">@label</p>
                <p class="value">@value</p>
            </div>
            <br />
            <br />
    }
