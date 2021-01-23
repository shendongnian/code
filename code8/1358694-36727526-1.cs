    using System.Diagnostics;
    
    frame = new StackTrace(e, true).GetFrame(0);
    controller = frame.GetMethod().DeclaringType.FullName;
    action = frame.GetMethod().ToString();
