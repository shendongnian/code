    private void GenerateAggregate()
    {
        uint sliderValue = 0;
        // generate the 2D aggregate of size given by particles_slider value
        Dispatcher.Invoke(() => { sliderValue = (uint)particles_slider.Value; });
        dla_2d.Generate(sliderValue);
        // TODO: add particles to "canvas" on GUI as they are generated
    }
