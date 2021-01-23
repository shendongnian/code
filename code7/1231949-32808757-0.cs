    unsafe{
        byte[] bytes = Encoding.ASCII.GetBytes(fileName);
        var _mdc = new TelsaMDC.TelsaMDCDetection();
        var outPut = new sbyte[256];  // Bad practice. Avoid using this!
        fixed (byte* p = bytes, p2 = outPut)
        {
            var sp = (sbyte*)p;
            var sp2 = (sbyte*)p2;
            //SP is now what you want
            _mdc.GetMDC(sp, sp2);
        }
    }
