    <telerik:RadGridView.Columns>
        <telerik:GridViewDataColumn DataMemberBinding="{Binding Dongle.DongleID}" Header="DongleID">
            <telerik:GridViewDataColumn.AggregateFunctions>
                <telerik:CountFunction ResultFormatString="{}Dongles: {0}" />
            </telerik:GridViewDataColumn.AggregateFunctions>
        </telerik:GridViewDataColumn>
        <telerik:GridViewDataColumn DataMemberBinding="{Binding OrderRows.Count}" Header="Licences"  
                                    CellStyleSelector="{StaticResource OrderDongleWrapTableCellStyleSelector}"
                                    CellTemplateSelector="{StaticResource OrderDongleWrapTableCellTemplateSelector}"  />
        <telerik:GridViewDataColumn DataMemberBinding="{Binding Customer.CustomerName}" Header="Customer"  
                                    CellStyleSelector="{StaticResource OrderDongleWrapTableCellStyleSelector}"
                                    CellTemplateSelector="{StaticResource OrderDongleWrapTableCellTemplateSelector}"  />
        <telerik:GridViewDataColumn DataMemberBinding="{Binding IsReplacementDongle}" Header="Replacement?" 
                                    IsVisible="False"
                                    CellStyleSelector="{StaticResource OrderDongleWrapTableCellStyleSelector}"
                                    CellTemplateSelector="{StaticResource OrderDongleWrapTableCellTemplateSelector}" />
        <telerik:GridViewDataColumn DataMemberBinding="{Binding IsEducationalDongle}" Header="Educational?"  
                                    CellStyleSelector="{StaticResource OrderDongleWrapTableCellStyleSelector}"
                                    CellTemplateSelector="{StaticResource OrderDongleWrapTableCellTemplateSelector}"  />
        <telerik:GridViewDataColumn DataMemberBinding="{Binding ReplacedDongle.DongleID}" Header="Replaced"  
                                    CellStyleSelector="{StaticResource OrderDongleWrapTableCellStyleSelector}"
                                    CellTemplateSelector="{StaticResource OrderDongleWrapTableCellTemplateSelector}"  />
        <telerik:GridViewDataColumn DataMemberBinding="{Binding ReplacedDongleStatus}" Header="Replacement Status"  
                                    CellStyleSelector="{StaticResource OrderDongleWrapTableCellStyleSelector}"
                                    CellTemplateSelector="{StaticResource OrderDongleWrapTableCellTemplateSelector}"/>
        <telerik:GridViewDataColumn DataMemberBinding="{Binding OrderRows[0].OrderRowCosts[0].CostValue }" Header="Sub-Total (AUD)">
        </telerik:GridViewDataColumn>
    </telerik:RadGridView.Columns>
