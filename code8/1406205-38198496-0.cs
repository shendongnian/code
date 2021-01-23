    <Page.Resources>
        <Style TargetType="HyperlinkButton" x:Key="myStyle" >
            ...
            <Setter Property="Template" x:Name="presenterSetter">
                <Setter.Value>
                    <ControlTemplate TargetType="HyperlinkButton">
                        <Grid x:Name="rootGrid">
                            ...
                            <Border x:Name="Border"
                                Background="{TemplateBinding Background}"
                                BorderBrush="{TemplateBinding BorderBrush}"
                                BorderThickness="{TemplateBinding BorderThickness}"
                                Margin="3">
                                <ContentPresenter x:Name="MyContentPresenter"
                                              Content="{TemplateBinding Content}"
                                              ContentTransitions="{TemplateBinding ContentTransitions}"
                                              HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"
                                              VerticalAlignment="{TemplateBinding VerticalContentAlignment}" 
                            >
                                    <ContentPresenter.ContentTemplate>
                                        <DataTemplate  x:Name="ttt">
                                            <Grid>
                                                <WebView Source="ms-appx-web:///Assets/Web/default.html" Name="myWebView"/>
                                            </Grid>
                                        </DataTemplate>
                                    </ContentPresenter.ContentTemplate>
                                </ContentPresenter>
                            </Border>
                            <!--focus visuals omitted-->
                        </Grid>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Page.Resources>
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <StackPanel VerticalAlignment="Bottom">
            <HyperlinkButton Name="myHyperlink" Style="{StaticResource myStyle}">This is a link</HyperlinkButton>
            <Button Click="Button_Click" Name="myBtn">Click Me</Button>
        </StackPanel>
    </Grid>
