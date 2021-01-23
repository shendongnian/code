    <TreeView Name="treeView" ItemsSource="{Binding Leafs}">
      <i:Interaction.Triggers>
        <i:EventTrigger EventName="SelectedItemChanged">
          <i:InvokeCommandAction Command="{Binding SetSelectedItemCommand, PresentationTraceSources.TraceLevel=High}" CommandParameter="{Binding SelectedItem, ElementName=treeView}" />
        </i:EventTrigger>
      </i:Interaction.Triggers>
    </TreeView>
