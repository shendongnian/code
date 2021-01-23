<pre>
public class BindingChild : BindingBase
{
    public string SampleProperty
    {
        get { return GetValue(() => SampleProperty); }
        set { SetValue(() => SampleProperty, value); }
    }
}
</pre>
