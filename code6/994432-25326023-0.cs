    <TextBlock xmlns:ref="clr-namespace:System.Reflection;assembly=mscorlib">
        <TextBlock.Text>
            <Binding Path="Version">
                <Binding.Source>
                    <ObjectDataProvider MethodName="GetName">
                        <ObjectDataProvider.ObjectInstance>
                            <ObjectDataProvider MethodName="GetExecutingAssembly"
                                                ObjectType="{x:Type ref:Assembly}" />
                        </ObjectDataProvider.ObjectInstance>
                    </ObjectDataProvider>
                </Binding.Source>
            </Binding>
        </TextBlock.Text>
    </TextBlock>
