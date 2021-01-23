public class SampleViewModel : ReactiveObject, ISupportsValidation
{
    public ValidationContext ValidationContext => new ValidationContext();
    
    // Bindable rule
	public ValidationHelper ComplexRule { get; set; }
    public SampleViewModel()
    {
         // name must be at least 3 chars - the selector heee is the property name and its a single property validator
         this.ValidationRule(vm => vm.Name, _isDefined, "You must specify a valid name");
    }
}
View
public class MainActivity : ReactiveAppCompatActivity<SampleViewModel>
{
    public EditText nameEdit { get; set; }
    public TextInputLayout til { get; set; }
    protected override void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);
        // Set our View from the "main" layout resource
        SetContentView(Resource.Layout.Main);
        WireUpControls();
        // bind to an Android TextInputLayout control, utilising the Error property
        this.BindValidation(ViewModel, vm => vm.ComplexRule, til);
    }
}
The View sample is taking advantage of the DroidExtensions (automatically added for Mono.Droid projects), but you can bind the error message to any control of your View.
I hope it helps.
Best regards.
