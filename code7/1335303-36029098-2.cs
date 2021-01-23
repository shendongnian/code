    // My base view model class
    public class ViewModelBase {
        public string MyText { get; set; }
    }
    // Some other view model
    public class MyOtherViewModel : ViewModelBase {
        // other properties
    }
    // In the _Layout view, implement the base class
    @model ViewModelBase
    ... 
    @Html.DisplayFor(m => m.MyText)
    ...
    @RenderBody()
    ...
