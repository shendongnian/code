    <ScrollViewer xmlns:l="clr-namespace:CSharpWPF">
        <ScrollViewer.Resources>
            <DataTemplate DataType="{x:Type l:CustomTable}">
                <DataTemplate.Resources>
                    <l:ErrorToVisibilityConverter x:Key="ErrorToVisibilityConverter" />
                    <Style TargetType="DataGridCell">
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="DataGridCell">
                                    <Grid Background="{TemplateBinding Background}">
                                        <StackPanel Orientation="Horizontal">
                                            <TextBlock Text=" ! "
                                                       FontWeight="Bold"
                                                       Foreground="Red">
                                                <TextBlock.Visibility>
                                                    <MultiBinding Converter="{StaticResource ErrorToVisibilityConverter}"
                                                                  Mode="OneWay">
                                                        <Binding RelativeSource="{RelativeSource FindAncestor,AncestorType=DataGridCell}" />
                                                        <Binding Path="Tag.Errors"
                                                                 RelativeSource="{RelativeSource FindAncestor,AncestorType=DataGrid}" />
                                                        <Binding />
                                                    </MultiBinding>
                                                </TextBlock.Visibility>
                                            </TextBlock>
                                            <ContentPresenter />
                                        </StackPanel>
                                    </Grid>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </DataTemplate.Resources>
                <StackPanel>
                    ...
                </StackPanel>
            </DataTemplate>
        </ScrollViewer.Resources>
        <ContentControl Content="{Binding TableCollection}" />
    </ScrollViewer>
