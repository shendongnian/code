    <ListView x:Name="lvAttachedRiskRelFiles" ItemsSource="{Binding Path=FileAttachments, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}"
                                        MouseDoubleClick="lvAttachedRiskRelFiles_MouseDoubleClick">
                                <ListView.View>
                                    <GridView>
                                        <scwpf:SortableGridViewColumn Header="Display Name" DisplayMemberBinding="{Binding DisplayName}" Width="Auto"/>
                                        <scwpf:SortableGridViewColumn DisplayMemberBinding="{Binding FileAttachmentAddedBy.DisplayName}" Width="Auto" Header="Added By"/>
                                        <scwpf:SortableGridViewColumn DisplayMemberBinding="{Binding Size}" Width="Auto" Header="Size" />
                                        <scwpf:SortableGridViewColumn DisplayMemberBinding="{Binding AddedDate}" Width="Auto" Header="Added Date"/>
                                    </GridView>
                                </ListView.View>
                            </ListView>
