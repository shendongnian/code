    // .. code ...
    <ListView ItemsSource="{Binding Formations}" IsItemClickEnabled="False" IsTapEnabled="False">
        <ListView.ItemContainerStyle>
            <Style TargetType="ListViewItem">
                  <Setter Property="Margin" Value="0, 0, 5, 0" />
                  <Setter Property="IsHitTestVisible" Value="False"/>
            </Style>
    // rest of the code
