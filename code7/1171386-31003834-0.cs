    <UserControl.Resources>
        <DataTemplate DataType="{x:Type viewModels:ReadingBookDoubleVM}">
            <ContentControl x:Name="Presenter" Content="{Binding}">
                <ContentControl.ContentTemplate>
                    <DataTemplate>
                        <view:ReadingBookDoubleView />
                    </DataTemplate>
                </ContentControl.ContentTemplate>
            </ContentControl>
            <DataTemplate.Triggers>
                <DataTrigger Binding="{Binding Kind}" Value="Pdf">
                    <Setter TargetName="Presenter"
                            Property="ContentTemplate">
                        <Setter.Value>
                            <DataTemplate>
                                <view:ReadingBookDoubleViewPdf />
                            </DataTemplate>
                        </Setter.Value>
                    </Setter>
                </DataTrigger>
            </DataTemplate.Triggers>
        </DataTemplate>
    </UserControl.Resources>
