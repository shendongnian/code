    <Slider Value="{Binding NewValue, UpdateSourceTrigger=PropertyChanged}">
        <b:Interaction.Triggers>
            <b:EventTrigger EventName="LostMouseCapture">
                <b:InvokeCommandAction Command="{Binding SliderLostFocusCommand}"/>
            </b:EventTrigger>
        </b:Interaction.Triggers>
    </Slider>
