    <Grid>
        <telerik:RadBusyIndicator IsBusy="{Binding ImBusy, UpdateSourceTrigger=PropertyChanged}">
            <telerik:RadGridView Margin="2"
                             ItemsSource="{Binding ChannelRuleMappings}"
                             SelectionUnit="FullRow"
                             SelectionMode="Extended" AutoGenerateColumns="False"
                             IsFilteringAllowed="False">
                <telerik:RadGridView.Columns>
                    <telerik:GridViewDataColumn Name="grdItemBuildColumn" DataMemberBinding="{Binding Build, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" IsReadOnlyBinding="{Binding IsEnable, Mode=OneWay, UpdateSourceTrigger= PropertyChanged}">
                        <telerik:GridViewDataColumn.CellEditTemplate>
                            <DataTemplate>
                                <telerik:RadMaskedNumericInput Value="{Binding Build, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" Mask="#1.0" Placeholder="*" 
                                                           TextMode="PlainText" 
                                                               UpdateValueEvent="LostFocus"
                                                               AllowInvalidValues="False" IsClearButtonVisible="False" AutoFillNumberGroupSeparators="False" 
                                                           maskedInput:MaskedInputExtensions.Minimum="0" SelectionOnFocus="SelectAll" AcceptsReturn="False">
                                    <i:Interaction.Triggers>
                                        <i:EventTrigger EventName="ValueChanged">
                                            <i:InvokeCommandAction Command="{Binding RelativeSource={RelativeSource Mode=FindAncestor, 
                                            AncestorType={x:Type telerik:RadGridView}}, Path=DataContext.BuidValueChangedCommand}"/>
                                        </i:EventTrigger>
                                    </i:Interaction.Triggers>
                                </telerik:RadMaskedNumericInput>
                            </DataTemplate>
                        </telerik:GridViewDataColumn.CellEditTemplate>
                    </telerik:GridViewDataColumn>
                </telerik:RadGridView.Columns>
            </telerik:RadGridView>
        </telerik:RadBusyIndicator>
    </Grid>
