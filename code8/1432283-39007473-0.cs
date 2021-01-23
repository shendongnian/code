            <DataGrid Name="tasksgrid" Margin="10,70,0,59"  AutoGenerateColumns="False">
            <DataGrid.Columns>               
                <DataGridTemplateColumn Header="Task ID">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate >
                            <TextBlock>
                                <Hyperlink Click="Hyperlink_Click_1" Tag="{Binding Path=ID}">
                                    <TextBlock Text="{Binding ID}"></TextBlock>
                                </Hyperlink>
                            </TextBlock>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
                <DataGridTextColumn Header="TASK ID" Binding="{Binding ID}"/>
                <DataGridTextColumn Header="Title" Binding="{Binding TITLE}" Width="250"/>
                <DataGridTextColumn Header="Resource" Binding="{Binding RESOURCE}"/>
                <DataGridTextColumn Header="customer" Binding="{Binding CUSTOMER}"/>
                <DataGridTextColumn Header="REQUESTED DATE" Binding="{Binding DATE_REQUESTED}"/>
                <DataGridTextColumn Header="DUE DATE" Binding="{Binding DUE_DATE}"/>
                <DataGridTextColumn Header="STATUS" Binding="{Binding STATUS}"/>
                <DataGridTextColumn Header="application" Binding="{Binding APPLICATION}"/>
                <DataGridTextColumn Header="REQUESTOR" Binding="{Binding REQUESTOR}"/>
                <DataGridTextColumn Header="Customer ticket" Binding="{Binding CUSTOMER_TICKET_NUM}"/>
                <DataGridTextColumn Header="PT Helpdesk #" Binding="{Binding PT_TICKET_NUM}"/>
                <DataGridTextColumn Header="Vendor Ticket Number" Binding="{Binding EXTERNAL_TICKET_NUM}"/>
                <DataGridTextColumn Header="DESCRIPTION" Binding="{Binding DESCRIPTION}" Width="400"/>               
            </DataGrid.Columns>
        </DataGrid>
