    <ControlTemplate TargetType="{x:Type DataGridColumnHeader}">
                        <Button x:Name="Btn" Command="{Binding Path=DataContext.FilterPopUpCommand, 
                                  RelativeSource={RelativeSource Mode=FindAncestor, 
                                                  AncestorType={x:Type Window}}}">
                            <Button.CommandParameter>
                                <MultiBinding Converter="{StaticResource MultiValueConverterKey}">
                                    <Binding RelativeSource="{ RelativeSource Mode=FindAncestor, 
                                                     AncestorType={x:Type cust:DataGrid}}" />
                                    <Binding Path="Column" 
                                   RelativeSource="{RelativeSource Mode=TemplatedParent}" />
                                    <Binding ElementName="Btn" />
                                </MultiBinding>
                            </Button.CommandParameter>
                        </Button>
                    </ControlTemplate>
