    //--------------------------------------------------------------------------------
    // Vendor-defined inputReport 05 (Device --> Host)
    //--------------------------------------------------------------------------------
    
    typedef struct
    {
      uint8_t  reportId;                                 // Report ID = 0x05 (5)
      uint8_t  VEN_VendorDefined0001[31];                // Usage 0xFF000001: , Value = 0 to 255
    } inputReport05_t;
    
    
    //--------------------------------------------------------------------------------
    // Vendor-defined inputReport 06 (Device --> Host)
    //--------------------------------------------------------------------------------
    
    typedef struct
    {
      uint8_t  reportId;                                 // Report ID = 0x06 (6)
      uint8_t  VEN_VendorDefined0001[60];                // Usage 0xFF000001: , Value = 0 to 255
    } inputReport06_t;
    
    
    //--------------------------------------------------------------------------------
    // Vendor-defined inputReport 07 (Device --> Host)
    //--------------------------------------------------------------------------------
    
    typedef struct
    {
      uint8_t  reportId;                                 // Report ID = 0x07 (7)
      uint8_t  VEN_VendorDefined0001[60];                // Usage 0xFF000001: , Value = 0 to 255
    } inputReport07_t;
    
    
    //--------------------------------------------------------------------------------
    // Vendor-defined inputReport 08 (Device --> Host)
    //--------------------------------------------------------------------------------
    
    typedef struct
    {
      uint8_t  reportId;                                 // Report ID = 0x08 (8)
      uint8_t  VEN_VendorDefined0001[60];                // Usage 0xFF000001: , Value = 0 to 255
    } inputReport08_t;
    
    
    //--------------------------------------------------------------------------------
    // Vendor-defined outputReport 01 (Device <-- Host)
    //--------------------------------------------------------------------------------
    
    typedef struct
    {
      uint8_t  reportId;                                 // Report ID = 0x01 (1)
      uint8_t  VEN_VendorDefined0001[4];                 // Usage 0xFF000001: , Value = 0 to 255
    } outputReport01_t;
    
    
    //--------------------------------------------------------------------------------
    // Vendor-defined outputReport 02 (Device <-- Host)
    //--------------------------------------------------------------------------------
    
    typedef struct
    {
      uint8_t  reportId;                                 // Report ID = 0x02 (2)
      uint8_t  VEN_VendorDefined0001[60];                // Usage 0xFF000001: , Value = 0 to 255
    } outputReport02_t;
    
    
    //--------------------------------------------------------------------------------
    // Vendor-defined outputReport 03 (Device <-- Host)
    //--------------------------------------------------------------------------------
    
    typedef struct
    {
      uint8_t  reportId;                                 // Report ID = 0x03 (3)
      uint8_t  VEN_VendorDefined0001;                    // Usage 0xFF000001: , Value = 0 to 255
    } outputReport03_t;
    
    
    //--------------------------------------------------------------------------------
    // Vendor-defined outputReport 04 (Device <-- Host)
    //--------------------------------------------------------------------------------
    
    typedef struct
    {
      uint8_t  reportId;                                 // Report ID = 0x04 (4)
      uint8_t  VEN_VendorDefined0001[2];                 // Usage 0xFF000001: , Value = 0 to 255
    } outputReport04_t;
    
    
    //--------------------------------------------------------------------------------
    // Vendor-defined outputReport 09 (Device <-- Host)
    //--------------------------------------------------------------------------------
    
    typedef struct
    {
      uint8_t  reportId;                                 // Report ID = 0x09 (9)
      uint8_t  VEN_VendorDefined0001[9];                 // Usage 0xFF000001: , Value = 0 to 255
    } outputReport09_t;
