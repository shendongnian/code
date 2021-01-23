    <Columns>
        <telerik:GridBinaryImageColumn UniqueName="BinaryImageColumn" />
        <telerik:GridBoundColumn DataField="PRODUCT_NAME" SortExpression="PRODUCT_NAME" HeaderText="<%$ Resources:Strings, ProductName %>" HeaderButtonType="TextButton" />
    </Columns>
    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
       GridDataItem item = e.Item as GridDataItem;
       if(item != null)
       {
          (item["BinaryImageColumn"].Controls[0] as RadBinaryImage).DataValue = yourImgByteArray;
       }
    }
