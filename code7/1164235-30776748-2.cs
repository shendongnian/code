    private const string secNotationPostfix = "\"";
    private static IList<CameraSettingItem> shutterSpeedList = new List<CameraSettingItem> {
        new CameraSettingItem {
            Id = ShutterSpeedDefaultValue,
            Description = string.Empty
        },
        new CameraSettingItem {
            Id = 1,
            Description = "30" + secNotationPostfix
        },
        ...
    };
    public static SelectList CreateShutterSpeedList() {
        return new SelectList(shutterSpeedList, "Id", "Description");
    }
    
