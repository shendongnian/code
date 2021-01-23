    <DataGridTemplateColumn.Visibility>
        <Binding Source="{StaticResource ResourceKey=DataContextProxy}"
                 Path="Data.IncludeThisColumn"
                 Converter="{StaticResource ResourceKey=BoolToHiddenConverter}"
                 />
    </DataGridTemplateColumn.Visibility>
