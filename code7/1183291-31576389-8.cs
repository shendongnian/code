    <telerik:RadGridView.Resources>                               
        <gridviewstyleselectors:LicenceTableCellStyleSelector x:Key="LicenceTableCellStyleSelector" />
    </telerik:RadGridView.Resources>
    <telerik:RadGridView.Columns>
        <telerik:GridViewDataColumn DataMemberBinding="{Binding DongleID}" Header="DongleID"  IsReadOnly="True" />
        <telerik:GridViewDataColumn DataMemberBinding="{Binding LicenceSerial}" Header="Serial"  IsReadOnly="True" />
        <telerik:GridViewDataColumn DataMemberBinding="{Binding LicenceStatus}" Header="Status"  IsReadOnly="True" 
                                    CellStyleSelector="{StaticResource LicenceTableCellStyleSelector}"/>
        <telerik:GridViewDataColumn DataMemberBinding="{Binding Product.ProductName}" Header="Product"  IsReadOnly="True" />
        <telerik:GridViewDataColumn DataMemberBinding="{Binding LicenceType}" Header="Licence Type" 
                                    CellStyleSelector="{StaticResource LicenceTableCellStyleSelector}" IsReadOnly="True" />
        <telerik:GridViewDataColumn DataMemberBinding="{Binding LicenceIssued}" Header="Issued" 
                                    CellStyleSelector="{StaticResource LicenceTableCellStyleSelector}" IsReadOnly="True" />
        <telerik:GridViewDataColumn DataMemberBinding="{Binding LicenceExpires}" Header="Expiry" 
                                    CellStyleSelector="{StaticResource LicenceTableCellStyleSelector}" IsReadOnly="True" />
    </telerik:RadGridView.Columns>
