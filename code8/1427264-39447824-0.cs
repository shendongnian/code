        <telerik:RadGrid RenderMode="Lightweight" ID="RadGrid1" runat="server">
      ...
      <MasterTableView DataSourceID="ProductsDataSource" TableLayout="Auto">
        ...
        <Columns>
          <telerik:GridBoundColumn DataField="ProductID" DataType="System.Int32" HeaderText="Product ID"
            SortExpression="ProductID" UniqueName="ProductID">
          </telerik:GridBoundColumn>
          <telerik:GridBoundColumn DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName"
            UniqueName="ProductName">
          </telerik:GridBoundColumn>
          <telerik:GridBoundColumn DataField="UnitPrice" DataType="System.Decimal" HeaderText="Unit Price"
            SortExpression="UnitPrice" UniqueName="UnitPrice">
          </telerik:GridBoundColumn>
        </Columns>
        ...
      </MasterTableView>
    </telerik:RadGrid>
