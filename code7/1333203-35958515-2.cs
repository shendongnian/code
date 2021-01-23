    float transX = System.BitConverter.ToSingle(receiveBuffer, 0);
    float transY = System.BitConverter.ToSingle(receiveBuffer, 8);
    float transZ = System.BitConverter.ToSingle(receiveBuffer, 16);
    float rotX = System.BitConverter.ToSingle(receiveBuffer, 4);
    float rotY = System.BitConverter.ToSingle(receiveBuffer, 12);
    float rotZ = System.BitConverter.ToSingle(receiveBuffer, 20);
