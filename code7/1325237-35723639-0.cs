<pre>
public abstract class BindingBase : INotifyPropertyChanged
{
    private IDictionary&lt;string, object&gt; _backingFields;
    private IDictionary&lt;string, object&gt; BackingFields
    {
        get { return _backingFields ?? (_backingFields = new Dictionary&lt;string, object&gt;(); }
    }    <br>
    protected T GetValue&lt;T&gt;(Expression&lt;Func&lt;T&gt;gt; expr)
    {
        var name = GetName(expr);
        return BackingFields.Contains(name) ? (T)BackingFields[name].Value : default(T);
    } <br>
    protected void SetValue&lt;T&gt;(Expression&lt;Func&lt;T&gt;gt; expr, T value)
    {
        var name = GetName(expr);
        if (BackingFields.Contains(name) && BackingFields[name].Value.Equals(value))
            return; // return without doing anything, since the value is not changing        <br>
        BackingFields[name] = value;
        RaisePropertyChanged(name);
    }<br>
    private void RaisePropertyChanged(string name)
    { // you know this part  
    }<br>
    private string GetName (Expression&lt;Func&lt;T&gt; expr)
    { // implementation can be found via google 
    }
}
</pre>
