    <Slider x:Name="LetterSlider" Orientation="Vertical"
                Value="{Binding SliderValue, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" 
                Maximum="{Binding MaxSliderLetter, Mode=OneTime}" 
				Minimum="{Binding MinSliderLetter, Mode=OneTime}" 
                RenderTransformOrigin="0.5,0.5">
            <Slider.RenderTransform>
                <RotateTransform Angle="180"/>
            </Slider.RenderTransform>
    </Slider>
