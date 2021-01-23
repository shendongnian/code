    <Style TargetType="MySpecialGrid">
      <Setter Property="Columns">
        <Setter.Value>
          <RadGridViewColumnsConfiguration>
            <GridViewDataColumn DataMemberBinding="{Binding SomeBinding}" Header="SomeHeader"/>
            <GridViewDataColumn DataMemberBinding="{Binding SomeBinding2}" Header="SomeHeader2"/>
            <GridViewDataColumn DataMemberBinding="{Binding SomeBinding3}" Header="SomeHeader3">
              <GridViewDataColumn.CellTemplate>
                <DataTemplate>
                  <... />
                </DataTemplate>
              </GridViewDataColumn.CellTemplate>
            </GridViewDataColumn>
          </RadGridViewColumnsConfiguration>
        </Setter.Value>
      </Setter>
      <Setter Property="Template">
        <Setter.Value>
          <ControlTemplate TargetType="MySpecialGrid">
            <RadGridView Columns="{TemplateBinding Columns}"/>
          </ControlTemplate>
        </Setter.Value>
      </Setter>
    </Style>
