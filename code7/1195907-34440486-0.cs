      <telerik:GridViewComboBoxColumn>
                <telerik:GridViewComboBoxColumn.ItemTemplate>
                    <DataTemplate>
                        <TextBlock>
                            <TextBlock.Text>
                                <MultiBinding diagnostics:PresentationTraceSources.TraceLevel="High" Converter="{StaticResource sensorCountConverter}">
                                    <Binding Path="NumberPhase" />
                                    <Binding Path="Data.PanelConfig.ID" Source="{StaticResource editedLocation}" />
                                </MultiBinding>
                            </TextBlock.Text>
                        </TextBlock>
                    </DataTemplate>
                </telerik:GridViewComboBoxColumn.ItemTemplate>
            </telerik:GridViewComboBoxColumn>
