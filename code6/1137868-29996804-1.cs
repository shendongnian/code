                <Grid.Visibility>
                    <MultiBinding Converter="{p:AccessLevelToVisibilityConverter}" >
                        <Binding Path="DataContext"  RelativeSource="{RelativeSource AncestorType=UserControl}" />
                        <Binding Path="." />
                    </MultiBinding>
                </Grid.Visibility>
