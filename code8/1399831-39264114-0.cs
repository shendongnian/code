    string actualScript = File(pathToFullLuaScriptOnDotNetServer).ReadToEnd();
    string luaSha = rClient.CalculateSha1(actualScript);
    //This current impl is not optimized - should do this in AppStart
    bool hasScript = rClient.HasLuaScript(luaSha);
    if (!hasScript)
    {
        luaSha = rClient.LoadLuaScript(CommWebAPI.RedisConfig.scriptString);
    }
 
...
   
    string geom = f["geometry"].ToString();
    string[] p = new string[] { integerParam + "", geom.StripNewLines() };
    List<string> result = rClient.ExecLuaShaAsList(luaSha, p);
    //getLuaScriptError is a custom function - see below
    string luaError = getLuaScriptError(result);
    if (null == luaError)
    {
        aggregatedResults = aggregatedResults.Union(result).ToList();
    }
    else
    {
        Debug.Print("Redis LUA error: " + luaError);
    }
