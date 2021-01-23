    <Foo.Resources>
        <BindableObjectReference
          x:Key="WorkspaceSelectorContainerReference"
          Object="{Binding ElementName=WorkspaceSelectorContainer}"/>
    </Foo.Resources>
    <DropDownButton x:Name="WorkspaceSelectorContainer" ...>
        <DropDownButton.DropDownContent>
            ...
            <ChangePropertyAction
                PropertyName="IsOpen"
                Value="False"
                TargetObject="{Binding Path=Object,
                    Source={StaticResource WorkspaceSelectorContainerReference}}"/>
            ...
        </DropDownButton.DropDownContent>
    </DropDownButton>
