        <TabControl>
            <TabControl.Resources>
                <Style TargetType="{x:Type Grid}" x:Key="TabItemGridBackground">
                    <Setter Property="Background" Value="Beige" />
                </Style>
            </TabControl.Resources>
            <TabControl.Items>
                <TabItem Header="Tab1">
                    <Grid Style="{StaticResource TabItemGridBackground}">
                        
                    </Grid>
                </TabItem>
                <TabItem Header="Tab2">
                    <Grid Style="{StaticResource TabItemGridBackground}">
                    </Grid>
                </TabItem>
                <TabItem Header="Tab3">
                    <Grid Style="{StaticResource TabItemGridBackground}">
                    </Grid>
                </TabItem>
            </TabControl.Items>
        </TabControl>
