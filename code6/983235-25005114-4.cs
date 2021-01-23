            <DataTemplate>
                <Rectangle>
                    <i:Interaction.Triggers>
                        <i:EventTrigger EventName="MouseDoubleClick">
                            <i:InvokeCommandAction Command="{Binding RectangleClickCommand}"
                                                   CommandParameter="{Binding}" />
                        </i:EventTrigger>
                    </i:Interaction.Triggers>
                </Rectangle>
            </DataTemplate>
