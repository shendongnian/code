    void OnCalculateClick(object sender, EventArgs e)
    {
        double width;
        double length;
        double depth;
        double volume;
        if (TryConvert(Length, out length) &&
            TryConvert(Width, out width) &&
            TryConvert(Depth, out depth))
        {
            volume = length * width * depth;
            string message = String.Format(
                "A box with length {0:0.0}, width {1:0.0}, and depth {2:0.0} has a volume of {3:0.00}.",
                length, width, depth, volume); 
            MessageBox.Show(message);
        }
    }
