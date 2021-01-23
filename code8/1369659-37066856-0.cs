    <Style TargetType="ListBoxItem">
      <Style.Triggers>
        <DataTrigger Binding="{Binding Path=ShouldButtonLookFocused}" Value="True">
          <!-- Whatever visual thing you can think of -->
          <Setter Property="Border" Value="Red" />
        </DataTrigger>	
      </Style.Triggers>
    </Style>
    public static readonly DependencyProperty ShouldButtonLookFocusedProperty =
        DependencyProperty.Register("ShouldButtonLookFocused",
        typeof(bool),
        typeof(WhicheverClassThisIsIn));
    public bool ShouldButtonLookFocused
    {
        get
        {
            return (bool)GetValue(ShouldButtonLookFocusedProperty);
        }
        set
        {
            SetValue(ShouldButtonLookFocusedProperty, value);
        }
    }
    <TextBox Name="SearchBox"
        IsFocused="{Binding Path=ShouldButtonLookFocused,
        Converter={StaticResource MyConverter}"
    />
