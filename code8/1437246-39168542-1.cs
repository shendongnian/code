    <telerik:RadGridView.Resources>
        <Style TargetType="telerik:GridViewRow">
            <Style.Triggers>
                <DataTrigger Binding="{Binding checkColorDataColumn}" Value="1">
                <DataTrigger.Setters>
                    <Setter Property="Background" Value="Blue" />
                </DataTrigger.Setters>
            </Style.Triggers>
        </Style>
    </telerik:RadGridView.Resources>
