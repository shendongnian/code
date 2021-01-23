           <GridViewColumn Header="First Name" DisplayMemberBinding="{Binding Path=FirstName}">
                <GridViewColumn.CellTemplate>
                    <DataTemplate>
                        <Button Content="{Binding}"/>
                    </DataTemplate>
                </GridViewColumn.CellTemplate>
            </GridViewColumn>
