        <ComboBox >
            <ComboBox.ItemTemplate>
                <ItemContainerTemplate>
                    <StackPanel>
                        <Image Source="{Binding Picture}"></Image>
                        <TextBlock ><Run Text="{Binding Name}"/></TextBlock>
                    </StackPanel>
                </ItemContainerTemplate>
            </ComboBox.ItemTemplate>
        </ComboBox>
