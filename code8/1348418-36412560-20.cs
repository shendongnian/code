    <TextBlock >
        <TextBlock.Text>
            <MultiBinding Converter="{StaticResource DeptCodeToDeptConverter}" >
                <Binding Path="DepartmentCode" />
                <Binding Path="DataContext.Departments" RelativeSource="{RelativeSource Findancestor, AncestorType={x:Type UserControl}}"/>
                <Binding>
                    <Binding.Source>
                        <sys:String>DepartmentCode</sys:String>
                    </Binding.Source>
                </Binding>
             </MultiBinding>
         </TextBlock.Text>
    </TextBlock>
