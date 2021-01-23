    <telerik:RadGridView x:Name="MyGrid" AutoGenerateColumns="False" ItemsSource="{Binding TestTypeList}">
		<telerik:RadGridView.Columns>
			<telerik:GridViewDataColumn DataMemberBinding="{Binding TestString}" />
			<telerik:GridViewDataColumn DataMemberBinding="{Binding TestInt}" />
			<telerik:GridViewDataColumn DataMemberBinding="{Binding TestCollection}">
				<telerik:GridViewDataColumn.CellTemplate>
                    <DataTemplate>
                        // Here give a template for the "TestCollection" when it is not in editing.
                    </DataTemplate>
                </telerik:GridViewDataColumn.CellTemplate>
				<telerik:GridViewDataColumn.CellEditTemplate>
					<DataTemplate>
						// Here give a template for the "TestCollection" when it is in editing.
					</DataTemplate>
				</telerik:GridViewDataColumn.CellEditTemplate>
			</telerik:GridViewDataColumn>			
		</telerik:RadGridView.Columns>
    </telerik:RadGridView>
