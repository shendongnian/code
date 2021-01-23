     <ItemsControl Name="icTodoList" ItemsSource="{Binding MyClass}">
                        <ItemsControl.ItemTemplate>
                                <DataTemplate>
                                        <StackPanel>
                        <Image Source="{Binding Image /*(MyClass.Image*/)"
                        <TextBlock Text="{Binding Title /*(MyClass.Title)*/}"
                                        </StackPanel>
                                </DataTemplate>
                        </ItemsControl.ItemTemplate>
                </ItemsControl>
