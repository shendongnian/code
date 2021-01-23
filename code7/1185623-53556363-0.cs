    public class DataGridHideBrowsableFalseBehavior : Behavior<DataGrid>
    {
        protected override void OnAttached()
        {
            AssociatedObject.AutoGeneratingColumn += AssociatedObject_AutoGeneratingColumn;
            base.OnAttached();
        }
        private void AssociatedObject_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (((PropertyDescriptor)e.PropertyDescriptor).IsBrowsable == false)
                e.Cancel = true;
        }
    }
    <DataGrid
        ItemsSource="{Binding Path=DataGridSource, Mode=OneWay}"
        AutoGenerateColumns="true">
            <i:Interaction.Behaviors>
                <behaviors:DataGridHideBrowsableFalseBehavior>
                 </behaviors:DataGridHideBrowsableFalseBehavior>
            </i:Interaction.Behaviors>
    </DataGrid>
