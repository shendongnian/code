    public class FileSizeConverter
    {
        public enum FileSizeSymbol
        {
            B,
            KB,
            MB,
            GB,
            TB
        }
    
        public string FormatByteSize(ref double fileSize, int decimalPlaces = 0)
        {
            var unit = FileSizeSymbol.B;
            while (fileSize >= 1024 && unit < FileSizeSymbol.TB)
            {
                fileSize = fileSize / 1024;
                unit++;
            }
    
            fileSize = Math.Round(fileSize, decimalPlaces, MidpointRounding.AwayFromZero);
    
            return unit.ToString();
        }
    }
