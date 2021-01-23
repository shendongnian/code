    @model WebApplication2.Models.FooVm
    <h2>Sample View</h2>
    @using ( Html.BeginForm( "YourAction", "YourController" ) )
    {
        <div class="container">
        @for ( int i = 0; i < Model.Bars.Count; i++ )
        {
            @Html.TextBoxFor( m => m.Bars[i].Fox )
            @Html.ValidationMessageFor( m => m.Bars[i].Fox );
        }
        </div>
    }
