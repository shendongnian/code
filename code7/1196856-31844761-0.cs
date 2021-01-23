    <Style x:Key='CustomCellStyle' TargetType="{x:Type DataGridCell}" >
            <Style.Triggers>
                <MultiTrigger >
                    <MultiTrigger.Conditions>
                        <Condition Property="IsMouseOver" Value="True" />
                        <Condition Property="IsSelected" Value="False" />
                        <Condition Property="IsReadOnly" Value="False" />
                    </MultiTrigger.Conditions>
                    <Setter Property="Background" Value="Blue" />
                </MultiTrigger>
                <MultiTrigger >
                    <MultiTrigger.Conditions>
                        <Condition Property="IsMouseOver" Value="True" />
                        <Condition Property="IsSelected" Value="False" />
                        <Condition Property="IsReadOnly" Value="True" />
                    </MultiTrigger.Conditions>
                    <Setter Property="Background" Value="LightBlue" />
                </MultiTrigger>
                <MultiTrigger >
                    <MultiTrigger.Conditions>
                        <Condition Property="IsMouseOver" Value="True" />
                        <Condition Property="IsSelected" Value="True" />
                        <Condition Property="IsReadOnly" Value="True" />
                    </MultiTrigger.Conditions>
                    <Setter Property="Background" Value="LightGray" />
                </MultiTrigger>
                <MultiTrigger >
                    <MultiTrigger.Conditions>
                        <Condition Property="IsMouseOver" Value="False" />
                        <Condition Property="IsSelected" Value="False" />
                        <Condition Property="IsReadOnly" Value="True" />
                    </MultiTrigger.Conditions>
                    <Setter Property="Background" Value="Gray" />
                </MultiTrigger>
                <MultiTrigger >
                    <MultiTrigger.Conditions>
                        <Condition Property="IsMouseOver" Value="False" />
                        <Condition Property="IsSelected" Value="True" />
                        <Condition Property="IsReadOnly" Value="True" />
                    </MultiTrigger.Conditions>
                    <Setter Property="Background" Value="Red" />
                </MultiTrigger>
            </Style.Triggers>
        </Style>
