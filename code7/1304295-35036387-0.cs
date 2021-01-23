    // This should be done in some initialization code and reuse the accessor
    // everywhere in your app...
    var accessor = TypeAccessor.Create(LogoObj.DataObjType.GetType()); 
    string propName = datatable_result.Rows[0][0].ToString().ToLowerInvariant();
    propName = propName[0].ToUpper() + propName.Substring(1);
    ms = logoApp.NewObj(accessor[LogoObj.DataObjType, propName]);
