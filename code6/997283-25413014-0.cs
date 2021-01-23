    public static class oDs
    {
        public static DataSet columnsxml
        {
            private static DataSet _oDs;
            get
            {
                if (_oDs == null)
                {
                    _oDs = new DataSet();
                    _oDs.ReadXml(HttpContext.Current.Server.MapPath("~/App_Data/Columns.xml"));
                }
                return _oDs;
            }
        }
    }
