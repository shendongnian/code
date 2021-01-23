    public void WriteDeviceStateToStream(StreamWriter stream, WhateverTheDeviceClassIs device)
    {
        //  Write fields in desired order of appearance in the file. 
        stream.Write(device.deviceID);
        //  There are many far superior ways to write a comma to the file, 
        //  and I'll hear about all of them in comments, but we're keeping 
        //  it as simple as possible for the moment.  
        stream.Write(",");
        stream.Write(device.model);
        stream.Write(",");
    
        //  Properties you just set
        stream.Write(device.Availability);
        stream.Write(",");
        stream.Write(device.rentID);
        stream.Write(",");
        stream.Write(device.rentName);
        stream.Write(",");
        stream.Write(device.rentSurname);
        stream.Write(",");
    
        stream.Write(device.OS);
        
        //  NOW write a newline.
        stream.WriteLine();
        //  DO NOT close the stream here. The stream belongs to the caller; make no 
        //  assumptions about what he plans to do with it next. 
    }
