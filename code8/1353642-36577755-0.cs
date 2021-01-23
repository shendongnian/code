    private System.Windows.Media.Color GetFadedColor(System.Windows.Media.Color start, System.Windows.Media.Color end, double ratio)
        {
            System.Diagnostics.Debug.Assert(ratio >= 0 && ratio <= 1);
            return System.Windows.Media.Color.FromArgb((byte)(start.A + (ratio * (end.A - start.A))), (byte)(start.R + (ratio * (end.R - start.R))), (byte)(start.G + (ratio * (end.G - start.G))), (byte)(start.B + (ratio * (end.B - start.B))));
        }
