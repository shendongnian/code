    [HttpPost]
            [AllowAnonymous]
            public DtoResultBase GetLog(DtoLog zippedLog)
            {
                return Resolve(() =>
                {
                    // just to check data
                    string imei = zippedLog.Imei;
                    DateTime start = zippedLog.DateStart;
                    DateTime end = zippedLog.DateEnd;
                    byte[] data = zippedLog.LogData;
    
                    return new DtoResultBase();
                });
            }
