    <Pivot Style="{StaticResource TabsStylePivotStyle}" Grid.Row="0">            
            <PivotItem>
                <PivotItem.Header>
                    <local:TabHeader Height="124" Label="Inbox" Glyph="&#xE719;"/>
                </PivotItem.Header>
                <PivotItem.Content>
                    <TextBlock Text="Content content content1"/>
                </PivotItem.Content>
            </PivotItem>
            <PivotItem>
                <PivotItem.Header>
                    <local:TabHeader Height="124" Label="Draft" Glyph="&#xE719;"/>
                </PivotItem.Header>
                <PivotItem.Content>
                    <TextBlock Text="Content content content2"/>
                </PivotItem.Content>
            </PivotItem>
            <PivotItem>
                <PivotItem.Header>
                    <local:TabHeader Height="124" Label="Outbox" Glyph="&#xE719;"/>
                </PivotItem.Header>
                <PivotItem.Content>
                    <TextBlock Text="Content content content3"/>
                </PivotItem.Content>
            </PivotItem>
        </Pivot>
