    ...
        <GroupBox
          Grid.Row="1"
          Grid.ColumnSpan="2"
          Grid.Column="2"
          FontWeight="Bold"
          Header="Select Service Type"
          Margin="0,7,0,0"
          Padding="2" >
            <ListBox  Margin="0,10,0,10" BorderThickness="0" Background="Transparent"
                ItemsSource="{Binding ServiceCosts}"
                SelectedItem="{Binding SelectedServiceCost}" >
                <ListBox.ItemContainerStyle>
                    <Style TargetType="{x:Type ListBoxItem}">
                        <Setter Property="IsSelected" Value="{Binding Path=IsSelected, Mode=TwoWay}" />
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="ListBoxItem">
                                    <ContentPresenter/>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </ListBox.ItemContainerStyle>
                <ListBox.ItemTemplate>
                    <DataTemplate>
                        <RadioButton Content="{Binding DescriptionPrice}"
                           IsChecked="{Binding Path=IsSelected, Mode=TwoWay,  RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type ListBoxItem}}}" Margin="0,5,0,5"/>
                    </DataTemplate>
                </ListBox.ItemTemplate>
            </ListBox>
        </GroupBox>
        ...
