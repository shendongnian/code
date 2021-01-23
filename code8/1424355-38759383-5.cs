    <Ribbon>
        <RibbonGroup Header="Category" Height="100">
            <RibbonComboBox Label="Category:" >
                <RibbonGallery SelectedItem="{Binding SelectedCategory, Mode=TwoWay, IsAsync=True}" >
                    <RibbonGalleryCategory  ItemsSource="{Binding Categories}" DisplayMemberPath="Name" ColumnsStretchToFill="True" MaxColumnCount="1" IsSharedColumnSizeScope="True" />
                </RibbonGallery>
            </RibbonComboBox>
            <RibbonComboBox Label="Subcategory:" >
                <RibbonGallery SelectedItem="{Binding SelectedSubCategory}" >
                    <RibbonGalleryCategory  ItemsSource="{Binding SelectedCategory.SubCategories}" DisplayMemberPath="Name" ColumnsStretchToFill="True" MaxColumnCount="1" IsSharedColumnSizeScope="True"/>
                </RibbonGallery>
            </RibbonComboBox>
            <RibbonButton Label="Edit Categories"  ToolTipTitle="Edit Categories" ToolTipDescription="Add, edit or delete categories and subcategories" Command="{Binding AddCatCommand}"></RibbonButton>
        </RibbonGroup>
    </Ribbon>
