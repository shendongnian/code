    <Style x:Key="EmptyContentControlStyle" TargetType="ContentControl">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="ContentControl" />
            </Setter.Value>
        </Setter>
    </Style>
    
    <DataTemplate>
        <ContentControl Style="{StaticResource EmptyContentControlStyle}">
            <Grid>
                <VisualStateManager.VisualStateGroups>
                ...
            </Grid>
        </ContentControl>
    </DataTemplate>
