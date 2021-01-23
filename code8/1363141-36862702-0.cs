    <Image>
        <Image.Resources>
            <stackoverflow:IdToImageSourceConverter x:Key="IdToImageSourceConverter"/>
        </Image.Resources>
        <Image.Style>
            <Style TargetType="Image">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding SelectedQuestion.containsImage}" Value="True">
                        <Setter Property="Source" Value="{Binding SelectedQuestion.id, Converter={StaticResource IdToImageSourceConverter}}"/>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Image.Style>
    </Image>
