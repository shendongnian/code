    <telerik:RadGridView x:Name="radGridView">
      <telerik:RadGridView.Columns>
        <telerik:GridViewDataColumn Header="First Name">
            <telerik:GridViewDataColumn.Style>
                <Style TargetType="{x:Type telerik:GridViewDataColumn}">
                  <Setter Property="DataMemberBinding" Value="{Binding FirstName}"/>
                  <Style.Triggers>
                      <DataTrigger Binding="{Binding FirstName}" Value="{x:Null}">
                          <Setter Property="DataMemberBinding" Value="{Binding FirstName2}"/>
                      </DataTrigger>
                  </Style.Triggers>
                </Style>
            </telerik:GridViewDataColumn.Style>
        </telerik:GridViewDataColumn>
      </telerik:RadGridView.Columns>
    </telerik:RadGridView>
