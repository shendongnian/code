    <ComboBox ItemsSource="{Binding Path=ChannelValues}"
              SelectedValue="{Binding Path=Channel, Mode=TwoWay}">
      <ComboBox.ItemTemplate>
        <DataTemplate>
          <TextBlock>
            <TextBlock.Text>
              <MultiBinding Converter="{StaticResource ResourceKey=ChannelNumConverter}">
                <Binding />
                <Binding Path="DataContext.SomeProperty"
                         RelativeSource="{RelativeSource Mode=FindAncestor,
                                          AncestorType=local:DataContextView}" />
              </MultiBinding>
            </TextBlock.Text>
          </TextBlock>
        </DataTemplate>
      </ComboBox.ItemTemplate>
    </ComboBox>
