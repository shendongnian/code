    if (SystemInfo.deviceType == DeviceType.Handheld) {
        _endPosition = HandleTouchInput();
    }
    else {
        _endPosition = HandleMouseInput();
    }
