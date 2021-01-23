                <RibbonMenuButton Label="FooGallery">
                    <RibbonGallery>
                        <RibbonGalleryCategory ItemsSource="{Binding GalleryItems}">
                            <RibbonGalleryCategory.ItemContainerStyle>
                                <Style TargetType="{x:Type RibbonGalleryItem}">
                                    <Setter Property="Content" Value="{Binding Content}"/>
                                    <Setter Property="IsSelected" Value="{Binding IsSelected}"/>
                                </Style>
                            </RibbonGalleryCategory.ItemContainerStyle>
                        </RibbonGalleryCategory>
                    </RibbonGallery>
                </RibbonMenuButton>
