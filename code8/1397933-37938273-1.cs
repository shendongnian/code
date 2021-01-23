    static readonly FontSize _defaultFontSize = new FontSize { Sup = 18, Small = 22, Normal = 26, Title = 28 };
    static readonly Dictionary<DeviceFamily, FontSize> _fontSizeMap = new Dictionary<DeviceFamily, FontSize>
    {
        { DeviceFamily.Phone,   new FontSize { Sup =  6, Small =  8, Normal = 12, Title = 14 } },
        { DeviceFamily.Tablet,  new FontSize { Sup =  8, Small = 12, Normal = 15, Title = 17 } },
        { DeviceFamily.Desktop, new FontSize { Sup = 12, Small = 15, Normal = 20, Title = 22 } }
    };
