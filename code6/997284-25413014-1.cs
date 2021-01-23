    public static class oDs
    {
        private static DataSet _oDs;
        public static DataSet columnsxml
        {
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
