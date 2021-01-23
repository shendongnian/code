csharp
public class ColorReference : INotifyPropertyChanged
{
    private Color color = Color.Black;
    public Color Color
    {
        get => this.color;
        set
        {
            this.color = value;
            this.OnPropertyChanged();
        }
    }
    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    [ NotifyPropertyChangedInvocator ]
    protected virtual void OnPropertyChanged([ CallerMemberName ] string propertyName = null)
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
    public static implicit operator Color(ColorReference colorReference) => colorReference.Color;
}
I'm not 100% positive that the `INotifyPropertyChanged` implementation is necessary but I figured it couldn't hurt (potentially allowing changing the color at runtime; I haven't tested this).
To use it, simply use it as a resource in a `ResourceDictionary`:
xaml
<Color x:Key="FirstColor">#51688f</Color>
...
<utility:ColorReference x:Key="SomeOtherColorName" Color="{StaticResource FirstColor}" />
In my use case, I'm using it to style Telerik controls with colors defined in my theme so that if I make a new theme, I don't need to copy the same color value all over the place. The obvious downside is that for any type other than `Color`, a new class would need to be defined, but I doubt I will need too many types to be aliased like this. Hopefully this helps someone else in the future trying to do the same thing I'm doing.
