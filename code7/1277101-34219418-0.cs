    <Style>
        <Style.Triggers>
            <DataTrigger Binding="{Binding RelativeSource={RelativeSource AncestorType=Grid},Path=IsMouseOver}" Value="True">
                <DataTrigger.EnterActions>
                    <Setter Property="SomeChildControlProperty: Value="SomeValue"
     />
                </DataTrigger.EnterActions>
                <DataTrigger.ExitActions>
                    <Setter Property ... and Value ... />
                </DataTrigger.ExitActions>
            </DataTrigger>
        </Style.Triggers>
    </Style>
