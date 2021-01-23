     <TabControl>
        <TabItem Header="TabItem" >
            <TabItem.Style>
                <Style TargetType="TabItem">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding Condition}" Value="True">
                            <Setter Property="Content">
                                <Setter.Value>
                                    <view:PaneView1 />
                                </Setter.Value>
                            </Setter>
                        </DataTrigger>
                        <DataTrigger Binding="{Binding Condition}" Value="False">
                            <Setter Property="Content" >
                                <Setter.Value>
                                        <view:PaneView2 />
                                    </Setter.Value>
                            </Setter>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </TabItem.Style>                    
        </TabItem>
        </TabControl>
