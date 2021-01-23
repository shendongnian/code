    <ContentControl x:Class="WpfApplication1.UserControl1">
        <ContentControl.Template>
            <ControlTemplate TargetType="ContentControl">
                <Border BorderBrush="Black" BorderThickness="1" Padding="0,5">
                    <ContentPresenter HorizontalAlignment="Center" Content="{TemplateBinding Content}"></ContentPresenter>
                </Border>
            </ControlTemplate>
        </ContentControl.Template>
