    public class FocusBehavior : Behavior<Entry>
    {
        private Entry _entry;
        public static readonly BindableProperty IsFocusedProperty =
            BindableProperty.Create("IsFocused",
                                    typeof(bool),
                                    typeof(FocusBehavior),
                                    default(bool),
                                    propertyChanged: OnIsFocusedChanged);
        public int IsFocused
        {
            get { return (int)GetValue(IsFocusedProperty); }
            set { SetValue(IsFocusedProperty, value); }
        }
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            _entry = bindable;
        }
        private static void OnIsFocusedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var behavior = bindable as FocusBehavior;
            var isFocused = (bool)newValue;
            if (isFocused)
            {
                behavior._entry.Focus();
            }
        }
    }
    <ListView x:Name="TasksListView"
              ItemsSource={Binding Tasks}
              RowHeight="200">
      <ListView.ItemTemplate>
        <DataTemplate>
          <ViewCell x:Name="ViewCell">
            <Grid x:Name="RootGrid"
                  Padding="10,10,10,0"
                  BindingContext="{Binding}">
              <Entry>
                  <Entry.Behaviors>
                    <helpers:FocusBehavior IsFocused="{Binding BindingContext.IsFocused, Source={x:Reference RootGrid}}"/>
                  </Entry.Behaviors>
              </Entry>
            </Grid>
          </ViewCell>
        </DataTemplate>
      </ListView.ItemTemplate>
    </ListView>
