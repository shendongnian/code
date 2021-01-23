    ...
    int getCityDB()
    {
    TZData *pTZ = NULL;
    int index;
    // load the library
    HINSTANCE hLib = LoadLibrary(_T("CityDB.dll"));
	if (hLib==NULL)
		return -1;
    // load the CityDB functions
    INITCITYDB InitCityDB = (INITCITYDB)GetProcAddress(
            hLib, _T("InitCityDb"));
    UNINITCITYDB UninitCityDB = (UNINITCITYDB)GetProcAddress(
            hLib, _T("UninitCityDb"));
    LOADTZDATA ClockLoadAllTimeZoneData = (LOADTZDATA)GetProcAddress(
            hLib, _T("ClockLoadAllTimeZoneData"));
    FREETZDATA ClockFreeAllTimeZoneData = (FREETZDATA)GetProcAddress(
            hLib, _T("ClockFreeAllTimeZoneData"));
    GETNUMZONES ClockGetNumTimezones = (GETNUMZONES)GetProcAddress(
            hLib, _T("ClockGetNumTimezones"));
    GETTZDATABYOFFSET ClockGetTimeZoneDataByOffset =
            (GETTZDATABYOFFSET)GetProcAddress(hLib, _T("ClockGetTimeZoneDataByOffset"));
    GETTZDATA ClockGetTimeZoneData = (GETTZDATA)GetProcAddress(
            hLib, _T("ClockGetTimeZoneData"));
    // Init the library
    InitCityDB();
    // load the TZ data
    ClockLoadAllTimeZoneData();
    // find out how many zones are defined
    int zoneCount = ClockGetNumTimezones();
    ...
