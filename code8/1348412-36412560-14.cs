    <StackPanel>
        <StackPanel.DataContext>
            <MultiBinding Converter="{StaticResource DeptCodeToDeptConverter}" >
                <Binding Path="DepartmentCode" />
                <Binding Path="DataContext.Departments" RelativeSource="{RelativeSource Findancestor, AncestorType={x:Type UserControl}}"/>
             </MultiBinding>
         </StackPanel.DataContext>
        <TextBlock Text="{Binding DepartmentCode>"/>
        <TextBlock Text="{Binding DepartmentName>"/>
    </StackPanel>
