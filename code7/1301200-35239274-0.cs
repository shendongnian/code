    <catel:Window.Resources>
        <catel:ViewModelToViewConverter x:Key="ViewModelToViewConverter" />
    </catel:Window.Resources>
    
    <catel:StackGrid x:Name="LayoutRoot">
        <ContentControl Content="{Binding CurrentPage, Converter={StaticResource ViewModelToViewConverter}}" />
    
        <ToolBar>
        <Button Name="btnConnectDisconnect" Command={Binding Connect} Content="Connect/Disconnect"/>
            <Button Name="btnFieldSettings" Command={Binding Field} Content="Field Settings"/>
            <Button Name="btnCalibration" Command={Binding Calibration} Content="Flowmeter Calibration"/>
        </ToolBar>
    </catel:StackGrid>
