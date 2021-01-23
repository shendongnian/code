     </StackPanel.Resources>
            <ContentControl HorizontalAlignment="Center" VerticalAlignment="Center" >
                <i:Interaction.Triggers>
                    <i:EventTrigger EventName="MouseLeftButtonDown">
                        <MvvmLight:EventToCommand Command="{Binding MessageInfoVm.ShowInfoMessageCommand}" CommandParameter="{Binding ToolTipOk}"/>
                    </i:EventTrigger>
                </i:Interaction.Triggers>
                <Button ToolTipService.ShowOnDisabled="True" ToolTip="{Binding ToolTipOk}"  Command="{Binding OkCommand}" />
            </ContentControl>
