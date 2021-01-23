    <ComboBox x:Name="PizzaCB" ItemsSource="{Binding ListPizza}">
    
    </ComboBox>
    <ComboBox x:Name="GiftCB" ItemsSource="{Binding ElementName=PizzaCB, Path=SelectedItem.Gifts}">
        <ComboBox.Style>
            <Style TargetType="ComboBox">
                <Setter Property="IsEnabled" Value="True"/>
                <Style.Triggers>
                    <DataTrigger Binding="{Binding ElementName=PizzaCB, Path=SelectedItem.Gifts}" Value="{x:Null}">
                        <Setter Property="IsEnabled" Value="False"/>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ComboBox.Style>
    </ComboBox> 
