    <Grid xmlns="http://xamarin.com/schemas/2014/forms"
                 xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
                 x:Class="Mobile.TypeTemplate">
    
        <Label Text="{Binding Name}" />
    
    </Grid>
    
    public partial class TypeTemplate : Grid
        {
            public TypeTemplate()
            {
                InitializeComponent();
            }
    
            public TypeTemplate(object item)
            {
                InitializeComponent();
                BindingContext = item;
            }
    
        }
