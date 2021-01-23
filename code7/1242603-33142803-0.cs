            <ContentControl Content="{Binding CurrentControlContent.Content}">
                <ContentControl.Resources>
                    <DataTemplate DataType="{x:Type soSandBoxListView:SingleTextModel}">
                        <TextBlock Text="{Binding SingleModelContent}" Background="Tan"></TextBlock>
                    </DataTemplate>
                    <DataTemplate DataType="{x:Type soSandBoxListView:MultipleTextModel}">
                        <StackPanel>
                            <TextBlock Text="{Binding FirstName}" Background="Yellow"></TextBlock>
                            <TextBlock Text="{Binding LastName}" Background="Red"></TextBlock>
                            <!--use the binding to your picture presentation in model-->
                            <Image Source="Resources/yotveta.jpg" Stretch="None"></Image>
                        </StackPanel>
                    </DataTemplate>
                </ContentControl.Resources>
            </ContentControl>
