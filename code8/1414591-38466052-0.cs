    <Button Content="Click me" Command="{Binding Path=CreateButtonCommand}">
                    <Button.Template>
                        <ControlTemplate TargetType="Button">
                            <WrapPanel>
                                <CheckBox Content="{Binding Path=Name}"  IsHitTestVisible="false" IsChecked="{Binding Path=IsChecked, Mode=OneWay}"/>
                                <ContentPresenter></ContentPresenter>
                            </WrapPanel>
                        </ControlTemplate>
                    </Button.Template>
                </Button>
