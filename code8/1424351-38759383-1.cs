    <RibbonGroup Header="Category" Height="100">
                    <RibbonComboBox Label="Category:" >
                        <RibbonGallery SelectedItem="{Binding SelectedCategory}" x:Name="gal">
                            <RibbonGalleryCategory  ItemsSource="{Binding Categories}" DisplayMemberPath="Text" ColumnsStretchToFill="True" MaxColumnCount="1" IsSharedColumnSizeScope="True" />
                        </RibbonGallery>
                    </RibbonComboBox>
                    <RibbonComboBox Label="Subcategory:" >
                        <RibbonGallery SelectedItem="{Binding SelectedSubcategory}">
                            <RibbonGalleryCategory DisplayMemberPath="Text" ItemsSource="{Binding Subcategories}"/>
                        </RibbonGallery>
                    </RibbonComboBox>
                    <RibbonButton Label="Edit Categories"  ToolTipTitle="Edit Categories" ToolTipDescription="Add, edit or delete categories and subcategories"></RibbonButton>
                </RibbonGroup>
