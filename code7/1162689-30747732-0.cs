       See the end of this message for details on invoking 
    just-in-time (JIT) debugging instead of this dialog box.
    
    ************** Exception Text **************
    System.IO.IOException: The parameter is incorrect.
    
       at System.IO.Ports.InternalResources.WinIOError(Int32 errorCode, String str)
       at System.IO.Ports.InternalResources.WinIOError()
       at System.IO.Ports.SerialStream.InitializeDCB(Int32 baudRate, Parity parity, Int32 dataBits, StopBits stopBits, Boolean discardNull)
       at System.IO.Ports.SerialStream..ctor(String portName, Int32 baudRate, Parity parity, Int32 dataBits, StopBits stopBits, Int32 readTimeout, Int32 writeTimeout, Handshake handshake, Boolean dtrEnable, Boolean rtsEnable, Boolean discardNull, Byte parityReplace)
       at System.IO.Ports.SerialPort.Open()
       at Serial_Oscilloscope.FormTerminal.button4_Click(Object sender, EventArgs e) in c:\Users\gokhan.sahin\Desktop\Real Time Scope Project\C#\Serial Oscilloscope\Serial Oscilloscope\FormTerminal.cs:line 533
       at System.Windows.Forms.Control.OnClick(EventArgs e)
       at System.Windows.Forms.Button.OnClick(EventArgs e)
       at System.Windows.Forms.Button.OnMouseUp(MouseEventArgs mevent)
       at System.Windows.Forms.Control.WmMouseUp(Message& m, MouseButtons button, Int32 clicks)
       at System.Windows.Forms.Control.WndProc(Message& m)
       at System.Windows.Forms.ButtonBase.WndProc(Message& m)
       at System.Windows.Forms.Button.WndProc(Message& m)
       at System.Windows.Forms.Control.ControlNativeWindow.OnMessage(Message& m)
       at System.Windows.Forms.Control.ControlNativeWindow.WndProc(Message& m)
       at System.Windows.Forms.NativeWindow.Callback(IntPtr hWnd, Int32 msg, IntPtr wparam, IntPtr lparam)
    
    
    ************** Loaded Assemblies **************
    mscorlib
        Assembly Version: 2.0.0.0
        Win32 Version: 2.0.50727.5420 (Win7SP1.050727-5400)
        CodeBase: file:///C:/Windows/Microsoft.NET/Framework/v2.0.50727/mscorlib.dll
    ----------------------------------------
    Program
        Assembly Version: 1.5.5582.19404
        Win32 Version: 1.5.5582.19404
        CodeBase: file:///C:/Program%20Files%20(x86)/program/Real%20Time%20Scope/program%20Real%20Time%20Scope.exe
    ----------------------------------------
    System.Windows.Forms
        Assembly Version: 2.0.0.0
        Win32 Version: 2.0.50727.5420 (Win7SP1.050727-5400)
        CodeBase: file:///C:/Windows/assembly/GAC_MSIL/System.Windows.Forms/2.0.0.0__b77a5c561934e089/System.Windows.Forms.dll
    ----------------------------------------
    System
        Assembly Version: 2.0.0.0
        Win32 Version: 2.0.50727.5420 (Win7SP1.050727-5400)
        CodeBase: file:///C:/Windows/assembly/GAC_MSIL/System/2.0.0.0__b77a5c561934e089/System.dll
    ----------------------------------------
    System.Drawing
        Assembly Version: 2.0.0.0
        Win32 Version: 2.0.50727.5420 (Win7SP1.050727-5400)
        CodeBase: file:///C:/Windows/assembly/GAC_MSIL/System.Drawing/2.0.0.0__b03f5f7f11d50a3a/System.Drawing.dll
    ----------------------------------------
    System.Configuration
        Assembly Version: 2.0.0.0
        Win32 Version: 2.0.50727.5420 (Win7SP1.050727-5400)
        CodeBase: file:///C:/Windows/assembly/GAC_MSIL/System.Configuration/2.0.0.0__b03f5f7f11d50a3a/System.Configuration.dll
    ----------------------------------------
    System.Xml
        Assembly Version: 2.0.0.0
        Win32 Version: 2.0.50727.5420 (Win7SP1.050727-5400)
        CodeBase: file:///C:/Windows/assembly/GAC_MSIL/System.Xml/2.0.0.0__b77a5c561934e089/System.Xml.dll
    ----------------------------------------
    
    ************** JIT Debugging **************
    To enable just-in-time (JIT) debugging, the .config file for this
    application or computer (machine.config) must have the
    jitDebugging value set in the system.windows.forms section.
    The application must also be compiled with debugging
    enabled.
    
    For example:
    
    <configuration>
        <system.windows.forms jitDebugging="true" />
    </configuration>
    
    When JIT debugging is enabled, any unhandled exception
    will be sent to the JIT debugger registered on the computer
    rather than be handled by this dialog box.
