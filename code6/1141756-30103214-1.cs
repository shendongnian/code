      public static AcumaticaWS.Field NewA4Field(string objName, string fldName)
        {
            AcumaticaWS.Field nv = new AcumaticaWS.Field();
            nv.ObjectName = objName;
            nv.FieldName = fldName.TrimEnd();
            return nv;
        }
