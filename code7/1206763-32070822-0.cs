      <Image.Style>
                <Style>
                                    <Style.Triggers>
                                        <DataTrigger Binding="{Binding ElementName=checkbox, Path=IsChecked,UpdateSourceTrigger=PropertyChanged}"
                                                     Value="True">
                                            <Setter Property="Image.Source"
                                                    Value="Back_jeans.jpg" />
                                        </DataTrigger>
                                        <DataTrigger Binding="{Binding ElementName=checkbox, Path=IsChecked,UpdateSourceTrigger=PropertyChanged}"
                                                     Value="False">
                                            <Setter Property="Image.Source"
                                                    Value="Blue_Front_Jeans.jpg" />
                                        </DataTrigger>
                                    </Style.Triggers>
                                </Style>
                            </Image.Style>
