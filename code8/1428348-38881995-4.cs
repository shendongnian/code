    <ItemsControl ItemsSource="{Binding TaxModels}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <StackPanel Orientation="Horizontal">
                    <TextBlock Text="{Binding Name}" />
                    <!-- DataTemplates in Resources will be used here automagically -->
                    <ContentControl Content="{Binding Assets}" />
                </StackPanel>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
        <ItemsControl.Resources>
            <DataTemplate TargetType="{x:Type models:AgricultureReturns}">
                <StackPanel Orientation="Horizontal">
                    <TextBlock Text="{Binding Name}" />
                    <TextBlock Text="{Binding FieldSizeinAcres}" />
                    <!-- etc -->
                </StackPanel>
            </DataTemplate>
            <DataTemplate TargetType="{x:Type models:CorporateAsset}">
                <StackPanel Orientation="Horizontal">
                    <TextBlock Text="{Binding CorporateOfficeName}" />
                    <TextBlock Text="{Binding NetWorth}" />
                    <!-- etc -->
                </StackPanel>
            </DataTemplate>
        </ItemsControl.Resources>
    </ItemsControl>
