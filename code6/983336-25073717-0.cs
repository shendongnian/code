    ; // EventLogMsgs.mc
    ; // ********************************************************
    ; // Use the following commands to build this file:
    ; //   mc -s EventLogMsgs.mc
    ; //   rc EventLogMsgs.rc
    ; //   link /DLL /SUBSYSTEM:WINDOWS /NOENTRY /MACHINE:x86 EventLogMsgs.Res 
    
    ; // ********************************************************
    ; // - Event categories -
    ; // Categories must be numbered consecutively starting at 1.
    ; // ********************************************************
    
    MessageIdTypedef = WORD
    
    LanguageNames = (English=0x409:MSG00409)
    
    MessageId = 0x1
    SymbolicName=GENERAL_CATEGORY
    Language=English
    General
    .
    
    MessageId = 0x2
    SymbolicName=DATABASE_CATEGORY
    Language=English
    Database
    .
    
    MessageId = 0x3
    SymbolicName=LOGON_CATEGORY
    Language=English
    Logon
    .
    
    MessageId = 0x4
    SymbolicName=LOGOFF_CATEGORY
    Language=English
    Logoff
    .
    
    MessageId = 0x5
    SymbolicName=EMAIL_CATEGORY
    Language=English
    Email
    .
    
    MessageId = 0x6
    SymbolicName=PRINTER_CATEGORY
    Language=English
    Printer
    .
    
    MessageId = 0x7
    SymbolicName=IO_CATEGORY
    Language=English
    IO
    .
    
    MessageId = 0x8
    SymbolicName=SERVICE_CATEGORY
    Language=English
    Service
    .
    
    MessageId = 0x9
    SymbolicName=DEBUG_CATEGORY
    Language=English
    Debug
    .
